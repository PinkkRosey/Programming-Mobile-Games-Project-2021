using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool disableMovement = false;
    public float timeRemaining = 3f;
    // Update is called once per frame
    void Update()
    {
        EnemyPathing finalPath = this.gameObject.GetComponent<PathFinding>().finalPath;
        if (finalPath != null)
        {

            //only run it if its not null

            if (finalPath.isEmpty() == false && disableMovement == false)
            {

                Vector3 movementTarget = new Vector3(finalPath.get0().getPosition().x, finalPath.get0().getPosition().y, 0);
                //if it has travelled to the next pos
                if (transform.position == movementTarget)
                {

                    finalPath.remove0Fromlist();
                    if (finalPath.get0() != null)
                    {
                        movementTarget = new Vector3(finalPath.get0().getPosition().x, finalPath.get0().getPosition().y, 0);
                        transform.position = Vector3.MoveTowards(transform.position, movementTarget, 0.05f);
                    }

                    //reassign the target pos to a new spot
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, movementTarget, 0.05f);
                }

                //move
            }

        }
        
    }
  
    void OnTriggerEnter2D(Collider2D collision)
    {
      
     if(collision.gameObject.tag == "character" )
        {
         
            disableMovement = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "character")
        {
          
            Invoke("DisableMovement", 0.5f);
        }
    }

    void DisableMovement()
    {
        
        disableMovement = false;
    }
}
