using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class Health : MonoBehaviour
{
    
    [SerializeField] public int maxHealth =10;

    private float Maxtimer = 0.3f;
    private int healAmount =3;
    private bool vWindow = false;
    private float currentTime;
    private bool colliding = true;
    private void Awake()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CameraCont.completedRunning == false)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Attacking.attack2 = false;
               
                
                
            }
            if (collision.gameObject.tag == "healthPot")
            {
                if (HealthSave.currentHealth + healAmount >= maxHealth)
                {
                    HealthSave.currentHealth = 10;
                }
                else
                {
                    HealthSave.currentHealth += healAmount;
                }

                Destroy(collision.gameObject);

            }
        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (CameraCont.completedRunning == false)
        {
           
            

                if (collision.CompareTag("Enemy"))
                {
                
                    Attacking.attack2 = false;
               
                
                }
                
            }
          
        }
       
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           
            
            Attacking.attack2 = true;
           
        }
    }

    private void FixedUpdate()
    {
        if (HealthSave.currentHealth <= 0)
        {
            HealthSave.maxLvL = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(11);
        }

        if(Attacking.attack2 ==false)
        {
            if(vWindow ==false)
            {
                vWindow = true;
                HealthSave.currentHealth--;
                Invoke("LoseHealth", 1f);
            }
            

        }
    }

    private void LoseHealth()
    {
        
        vWindow = false;
    }
}
