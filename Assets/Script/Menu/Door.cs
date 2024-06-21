using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int sceneToLoad;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
