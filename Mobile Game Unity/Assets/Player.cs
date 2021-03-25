using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    // Update is called once per frame
    void FixedUpdate()
    {
        
            rb.velocity = movementJoystick.joystickVec * playerSpeed;


        
    }
}
