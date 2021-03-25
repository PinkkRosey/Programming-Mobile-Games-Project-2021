using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    private float transitionTime;
    public static bool completedRunning;
    [SerializeField] private Vector3 savedPos;
    private UnityEngine.Camera cam;

    private void Awake()
    {
        cam = UnityEngine.Camera.main;
       
     
            Camera.main.orthographicSize = 26*cam.aspect;
        
      
    }
    
    void Start()
    {
        

        completedRunning = false;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame

    private void Update()
    {
     
        if (transform.position.y ==savedPos.y)
        {
            completedRunning = false;
        }
        

    }
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        float dist = Vector2.Distance(player.transform.position, transform.position);
       
        


        if (dist >= 11)
        {
           

            float test2 = (player.transform.position.y + offset.y )* 100;
            int test3 = (int)test2;
            float test4 = test3 / 100;
            
            savedPos = new Vector3(transform.position.x, test4, transform.position.z);

            completedRunning = true;

        }

        if(completedRunning ==true)
            {
            CameraMover();
        }




       
       
}

    void CameraMover()
    {

        transform.position = Vector3.MoveTowards(transform.position, savedPos, Time.deltaTime * 4f);
    }

        
    }



