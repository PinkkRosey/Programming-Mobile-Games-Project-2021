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
    private bool attack = true;
    private List<GameObject> enemies = null;
    public static int enemiesLength;

    private void Start()
    {
        enemyCounting();
    }
    private void FixedUpdate()
    {

        if (movementJoystick.joystickVec.y != 0)

        {
            //only attack while moveing
            return;
        }
        else if(attack ==true)
        {
            attack = false; //Set it to false to avoid running again until 1 sec has passed
            Invoke("Attack", 0.3f);
            
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
        
     

        if(enemiesLength >0)
        {
            enemyCounting();
            float distanceTo = Vector2.Distance(this.transform.position, enemies[0].transform.position);
            if(distanceTo <=4)
            {
                Vector3 direction = -(this.transform.position - enemies[0].transform.position).normalized *5;
               if(enemies[0].GetComponent<EnemyHealth>().enemyHealth>=1)
                {
                    GameObject particle = Instantiate(bullet, spawnPoint);
                    particle.GetComponent<Rigidbody2D>().velocity = direction;
                }
                
            }
            attack = true;

        }
       

       
        
    }
    public void sortEnemyListList(List<GameObject> enemies)
    {
        enemies.Sort((x, y) => Vector2.Distance(x.transform.position,this.transform.position).CompareTo(Vector2.Distance(y.transform.position, this.transform.position)));
        //Sort the list based on distance
    }

}
