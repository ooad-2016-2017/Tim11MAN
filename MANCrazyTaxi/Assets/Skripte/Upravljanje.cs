using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upravljanje : MonoBehaviour {

    public float speed = 1500f;
    public float rotationSpeed = 15f;

    public WheelJoint2D Nazad;
    public WheelJoint2D Napred;

    public Rigidbody2D rb;

    private float movement = 0f;
    private float rotation = 0f;

    void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed;
        rotation = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (movement == 0f)
        {
            Nazad.useMotor = false;
            Napred.useMotor = false;
        }
        else
        {
            Nazad.useMotor = true;
            Napred.useMotor = true;

            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            Nazad.motor = motor;
            Napred.motor = motor;
        }

        rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
