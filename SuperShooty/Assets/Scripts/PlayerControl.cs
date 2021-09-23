using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
"My momma always said life is like a box of chocolates; You never know what you're gonna get."
 -Forrest Gump
*/
public class PlayerControl : MonoBehaviour
{
    public float Speed = 500;
    public float RotationSpeed = 10;
    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called 30 times/second
    void FixedUpdate()
    {
        // I say, give me the input, good sir!
        float ySpeed = Input.GetAxisRaw("Vertical") * Speed;
        float rotSpeed = Input.GetAxisRaw("Horizontal") * RotationSpeed;

        // Forces & Torque exist.
        myRb.AddForce(transform.up * ySpeed * Time.fixedDeltaTime);
        myRb.AddTorque(rotSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
