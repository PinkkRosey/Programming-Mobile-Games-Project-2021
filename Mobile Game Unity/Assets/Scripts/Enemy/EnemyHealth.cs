using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int enemyHealth;
   
    // Start is called before the first frame update

    private void Start()
    {
        maxHealth = enemyHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CameraCont.completedRunning == false)
        {
            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                enemyHealth--;
            }
        }
    }
    private void Update()
    {
        if (enemyHealth<=0)
        {
            Attacking.enemiesLength--;
            Destroy(this.gameObject);
        }
    }
}
