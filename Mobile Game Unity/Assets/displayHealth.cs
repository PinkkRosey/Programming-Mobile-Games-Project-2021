using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHealth : MonoBehaviour
{
    [SerializeField] private Text txt;
    private int healthD;
 

    private void Awake()
    {
        healthD = HealthSave.currentHealth;
        txt.text = HealthSave.currentHealth.ToString();
       
    }


private void Update()
    {
        if(healthD != HealthSave.currentHealth)
        {
            txt.text = HealthSave.currentHealth.ToString();
            healthD = HealthSave.currentHealth;
        }
        
    }
}
