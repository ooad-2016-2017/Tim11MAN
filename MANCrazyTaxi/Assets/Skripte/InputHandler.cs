using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Upravljanje upravljanje;
    // kada bi se dodaju neki novi nacini upravljanja (sa novim tipkama) ovdje bi se oni dodali
    private float movement = 0f;
    bool isReplaying;

    void Start()
    {
        upravljanje = new DoNothing();
        // novi nacini bi se ovdje inicijalizirali 
    }

    void Update()
    {
        HandleInput();

    }

    public void HandleInput()
    {
        float movement = 0f;
        upravljanje = new Upravljanje();
        // ovdje bi se novi nacini pozvali zavisno od toga koja je tipka pritisnuta

    }
}