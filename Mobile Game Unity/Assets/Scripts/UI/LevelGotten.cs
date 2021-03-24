using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGotten : MonoBehaviour
{
    [SerializeField] private Text txt;
    // Start is called before the first frame update
    void Awake()
    {
        if(HealthSave.maxLvL =="finalLevel")
        {
            txt.text = "You beat the game! Congratulations!!";
        }
        else
        {
            txt.text = "You made it to Level : " + HealthSave.maxLvL;
        }
      
    }

    
}
