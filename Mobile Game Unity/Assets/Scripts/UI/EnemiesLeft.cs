using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeft : MonoBehaviour
{
    [SerializeField] private Text txt;
    
    [SerializeField] private int enemiesLeft;

    private void Start()
    {
        enemiesLeft = Attacking.enemiesLength;
        txt.text = "Enemies Left:" + enemiesLeft.ToString();
    }
    private void Update()
    {

        enemiesLeft = Attacking.enemiesLength;
        txt.text = "Enemies Left:" + enemiesLeft.ToString();
    }
    

}
