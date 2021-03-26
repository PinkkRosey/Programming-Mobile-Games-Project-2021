using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private MovementJoystick movementJoystick;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject doorClosed;
    [SerializeField] private GameObject doorOpen;
    [SerializeField] private LayerMask affected;
    [SerializeField] public static bool attack = true;
    [SerializeField] public static bool attack2 = true;
    private static List<GameObject> enemies = null;
    public static int enemiesLength;
  

    private void Start()
    {
        attack = true;
        attack2 = true;
        enemyCounting();
    }
    private void FixedUpdate()
    {

        if (CameraCont.completedRunning == false)
        {
            if (movementJoystick.joystickVec.y != 0)

            {
                //only attack while moveing
                return;
            }
            else if (attack == true && attack2 ==true)
            {

                attack = false; //Set it to false to avoid running again until 1 sec has passed
                Attack();

            }
        }
        
    }
    private void LateUpdate()
    {
        
        if (enemiesLength == 0)
        {
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
            
        }
        
      
           
        
    }

    private bool VisionCheck()
    {
        if(enemies[0] ==null)
        {
            return false;
        }
        //we update the playerCount every attack, there is a small delay to this the idea is that in theory we sh
        float distanceTo = Vector2.Distance(this.transform.position, enemies[0].transform.position);
        Vector2 dir = -(transform.position - enemies[0].transform.position);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y ), dir,distanceTo +1f, affected);
    
        // Does the ray intersect any objects excluding the player layer
     
        if (hit.collider ==null)
        {
            return false;
         
        }
        else if(hit.collider.CompareTag("Enemy"))
        {

            return true;

        }
        else
        {
            return false;
        }
       
    }
    public void enemyCounting()
    {
        enemies = new List<GameObject>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(go);
            sortEnemyListList(enemies);

        }
        enemiesLength = enemies.Count;
    }

    
    private void Attack()
    {

        enemyCounting();

        if (enemiesLength != 0)
        {
            float distanceTo = Vector2.Distance(this.transform.position, enemies[0].transform.position);
            //The distance to the enemy, if its close enough to us start checking if we are in vision range
            if (distanceTo <=4.0f)
            {


                if (VisionCheck() == true)
                {

                    if (enemies[0].GetComponent<EnemyHealth>().enemyHealth >= 1)
                    {
                        Vector3 direction = -(transform.position - enemies[0].transform.position).normalized * 5;
                        GameObject particle = Instantiate(bullet, spawnPoint);
                        particle.GetComponent<Rigidbody2D>().velocity = direction;
                    }
                    Invoke("shootWindow", 0.5f);

                }
                else
                {
                    attack = true;
                }

                
            }
            else
            {
                attack = true;
            }
        }

       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    public void shootWindow()
    {
        attack = true;
    }
    public void sortEnemyListList(List<GameObject> enemies)
    {
        enemies.Sort((x, y) => Vector2.Distance(x.transform.position,this.transform.position).CompareTo(Vector2.Distance(y.transform.position, this.transform.position)));
        //Sort the list based on distance
    }

}
