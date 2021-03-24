using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    

    public void tryAgain()
    {
        HealthSave.maxLvL = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(1);
    }

    public void Exiting()
    {
        Application.Quit();
    }
}
