using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("character"))
        {
            Scene scene = SceneManager.GetActiveScene();
            int sceneIndex = scene.buildIndex;
            

            int nextIndex = sceneIndex + 1;
            if(nextIndex ==11 )
            {
                HealthSave.maxLvL = "finalLevel";
                SceneManager.LoadScene(nextIndex);
            }
            else
            {
                SceneManager.LoadScene(nextIndex);
            }
            
        }
    }
}
