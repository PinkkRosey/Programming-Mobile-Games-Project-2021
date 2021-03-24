using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool disableMovement = false;
    public float timeRemaining = 3f;
    public bool hasMovedToNextPos ;
    [SerializeField] private float movementSpeed;
    [SerializeField] private PathFinding enemyPath;
    [SerializeField] private GameObject player;
    private bool activateMovement = false;
    
    

    // Update is called once per frame

    void Start()
    {
       
    }
    private void Awake()
    {
        hasMovedToNextPos = true;
    }
    void FixedUpdate()
    {
        
        
        
        if (enemyPath.finalPath != null)
        {
         
            if (enemyPath.finalPath.returnCount() > 0 )
            {


                Vector3 movementTarget = new Vector3(enemyPath.finalPath.get0().getPosition().x, enemyPath.finalPath.get0().getPosition().y, 0);
                //if it has travelled to the next pos
                if (transform.position == movementTarget)
                {

                    hasMovedToNextPos = true;
                    enemyPath.finalPath.remove0Fromlist();
                    
                    if (enemyPath.finalPath.returnCount() > 0)
                    {

                        movementTarget = new Vector3(enemyPath.finalPath.get0().getPosition().x, enemyPath.finalPath.get0().getPosition().y, 0);
                        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed);
                    }
                   
                    //reassign the target pos to a new spot
                }
                else
                {
                    hasMovedToNextPos = false;
                    transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed);
                }

                //move
            }


        }
    }
  
    void OnTriggerEnter2D(Collider2D collision)
    {
      
     if(collision.gameObject.tag == "CollisionCheck" )
        {


            hasMovedToNextPos = false;
            disableMovement = true;
        }
       
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CollisionCheck")
        {
           
            Invoke("DisableMovement", 0.5f);
        }
      
    }

    void DisableMovement()
    {
       
        disableMovement = false;
       
    }
}
