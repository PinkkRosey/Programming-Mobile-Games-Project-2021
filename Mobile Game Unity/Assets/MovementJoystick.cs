using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementJoystick: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject joystick;
    public GameObject joystickParent;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    [SerializeField] private float joystickRadius;

    private Image imageBG;
    private Image joystickHandle;

    
    void Awake()
        
    {

        imageBG = joystick.GetComponent<Image>();
        joystickHandle = joystickBG.GetComponent<Image>();
        imageBG.enabled = false;
        joystickHandle.enabled = false;
        joystickOriginalPos = joystickBG.transform.position;
        
    }

    public void PointerDown()
    {
        if (CameraCont.completedRunning == false)
        {
            imageBG.enabled = true;
            joystickHandle.enabled = true;
           
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                joystickTouchPos = Input.mousePosition;
                joystickParent.transform.position = Camera.main.ScreenToWorldPoint(joystickTouchPos);
            }
            else
            {
                joystickTouchPos = Input.GetTouch(0).position;
                joystickParent.transform.position = Camera.main.ScreenToWorldPoint(joystickTouchPos);
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
        imageBG.enabled = false;
        joystickHandle.enabled = false;
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickBG.transform.position;
        
        
    }

    private void Update()
    {
        if(CameraCont.completedRunning ==true)
        {
            
                joystickVec = Vector2.zero;
                joystick.transform.position = joystickBG.transform.position;
            
        }
    }
}
