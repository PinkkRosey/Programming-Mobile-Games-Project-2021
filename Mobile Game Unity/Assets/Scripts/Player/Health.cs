using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth =10;
    

    private int healAmount =3;
    private bool vWindow = false;

    private void Awake()
    {
        Debug.Log(HealthSave.currentHealth);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            vWindow = true;

            HealthSave.currentHealth--;
            Invoke("LoseHealth", 0.5f);
        }
        if (collision.gameObject.tag =="healthPot")
        {
            if(HealthSave.currentHealth + healAmount >= maxHealth)
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(vWindow ==false)
        {
            
            if (collision.gameObject.tag == "Enemy")
            {
                vWindow = true;

                HealthSave.currentHealth--;
                Invoke("LoseHealth", 0.5f);
            }
        }
       
    }

    private void FixedUpdate()
    {
        if (HealthSave.currentHealth <= 0)
        {
            HealthSave.maxLvL = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(11);
        }
    }

    void LoseHealth()
    {
        
        vWindow = false;
    }
}
