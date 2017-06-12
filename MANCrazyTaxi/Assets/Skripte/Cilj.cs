using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Cilj : MonoBehaviour {

    public Text najbolji;
    public Text trenutni;
    private int n;
    private int t;

    void OnTriggerEnter2D(Collider2D colInfo)
    {

        if (colInfo.CompareTag("Player"))
        {

            if (int.TryParse(trenutni.text.ToString(), out t))
                t = Convert.ToInt32(trenutni.text.ToString());
            if(int.TryParse(najbolji.text.ToString(), out n))
                n = Convert.ToInt32(najbolji.text.ToString());
            if (t < n || n==0)
            {
                najbolji.text = t.ToString();
                PlayerPrefs.SetInt("najboljiskor", t);
                PlayerPrefs.Save();
            }

            Debug.Log("GAME WON! :D");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
