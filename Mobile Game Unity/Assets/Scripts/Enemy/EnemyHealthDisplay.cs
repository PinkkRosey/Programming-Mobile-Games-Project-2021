using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{

    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Image healthImage;
    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = (float)enemyHealth.enemyHealth / (float)enemyHealth.maxHealth;
    }
}
