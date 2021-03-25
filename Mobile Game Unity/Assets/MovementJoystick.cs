using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    [SerializeField] private float joystickRadius;
    private float timeCount = 0.0f;


    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        
    }

    public void PointerDown()
    {
        if (CameraCont.completedRunning == false)
        {
            joystickOriginalPos = joystickBG.transform.position;
            
            if(Application.platform == RuntimePlatform.WindowsEditor)
            {
                joystickTouchPos = Input.mousePosition;
            }
            else
            {
                joystickTouchPos = Input.GetTouch(0).position;
            }
            
        }
    }


    public void Drag(BaseEventData baseEventData)
    {
        if (CameraCont.completedRunning == false)
        {

            joystickOriginalPos = joystickBG.transform.position;
            PointerEventData pointerEventData = baseEventData as PointerEventData;
            Vector2 dragPos = pointerEventData.position;
            joystickVec = (dragPos - joystickTouchPos).normalized;





            joystick.transform.position = joystickOriginalPos + joystickVec * joystickRadius;

        }

    }
    public void PointerUp()
    {
        if (CameraCont.completedRunning == false)
        {
            joystickVec = Vector2.zero;
            joystick.transform.position = joystickBG.transform.position;
        }
        
    }

    private void Update()
    {
        if(CameraCont.completedRunning ==true)
        {
            if (CameraCont.completedRunning == false)
            {
                joystickVec = Vector2.zero;
                joystick.transform.position = joystickBG.transform.position;
            }
        }
    }
}
