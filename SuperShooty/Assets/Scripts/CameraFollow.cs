using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("Drag object to follow here.")]
    public GameObject Target;
    [Tooltip("Set between 0 and 1 for speed."), Range(0,1)]
    public float LerpVal = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called 30 times/second
    void FixedUpdate()
    {
        if (Target != null)
        {
            // Calculate where I am going towards.
            Vector3 newPos = Target.transform.position;
            newPos.z = transform.position.z;
            // Lerp towards the target to smooth movement.
            transform.position = Vector3.Lerp(transform.position, newPos, LerpVal);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
