using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthImage;
    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = (float)health.playerHealth / (float)health.maxHealth;
    }
}
