using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kraj : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D colInfo)
    {

        if (colInfo.CompareTag("Collidable"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
