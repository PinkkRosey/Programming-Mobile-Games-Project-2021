using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthImage;
    // Update is called once per frame

    private void Start()
    {
        healthImage.fillAmount = (float)HealthSave.currentHealth / (float)health.maxHealth;
    }
    void Update()
    {
        healthImage.fillAmount = (float)HealthSave.currentHealth / (float)health.maxHealth;
    }
}
