using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class Health : MonoBehaviour
{
    
    [SerializeField] public int maxHealth =10;
    [SerializeField] private SpriteRenderer characters;

    private int healAmount =3;
    private bool vWindow = false;
   

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
                
                characters.color = Color.red;
                HealthSave.currentHealth--;
                Invoke("LoseHealth", 0.3f);
            }
            

        }
    }

    private void LoseHealth()
    {

        characters.color = new Color(1f, 1f, 1f, 1f);
        vWindow = false;
    }
}
