using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    private float start;
    private bool kraj = false;

	// Use this for initialization
	void Start () {
        start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (kraj) return;
        float t = Time.time-start;
        string sec = t.ToString("f0");
        timer.text = sec;
    }

    public void Kraj()
    {
        kraj = true;
    }
}
