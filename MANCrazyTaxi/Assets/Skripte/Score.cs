using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class Score : MonoBehaviour {

    public Text najbolji;
    public Text trenutni;
    private int n;
    private int t;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("najboljiskor"))
            n=PlayerPrefs.GetInt("najboljiskor",0);
            najbolji.text = n.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
