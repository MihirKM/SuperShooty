using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour
{
    public float Speed = 500;
    public float RotationSpeed = 10;
    Rigidbody2D myRb;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        PlayerControl pC = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        // I say, give me the input, good sir!
        float ySpeed = joystick.Vertical * Speed;
        float rotSpeed = -joystick.Horizontal * RotationSpeed;

        // Forces & Torque exist.
        myRb.AddForce(transform.up * ySpeed * Time.fixedDeltaTime);
        myRb.AddTorque(rotSpeed * Time.fixedDeltaTime);
    }
}
