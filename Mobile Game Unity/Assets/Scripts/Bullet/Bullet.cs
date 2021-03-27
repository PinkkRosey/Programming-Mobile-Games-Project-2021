using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float travelTime = 0.0f;
    private float collisionCount;
    private void Start()
    {
        collisionCount = 0;
        transform.parent = null;
    }
    private void OnTriggerStay2D(Collider2D collision)
    { 
      
    }

    private void Update()
    {
        Debug.Log(travelTime);
        travelTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 7 || collision.gameObject.layer == 8) &&travelTime>0)
        {
            Destroy(gameObject);
        }
        //this makes it so if you are colliding with a wall currently your travel time will increase and on the NEC
    }
  
}
