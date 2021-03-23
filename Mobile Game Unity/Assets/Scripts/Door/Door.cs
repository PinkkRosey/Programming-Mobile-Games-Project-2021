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
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }
}
