using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [-_-]

public class PaceAndChaseAI : MonoBehaviour
{
    [Tooltip("Points that the AI should move through while Pacing.")]
    public Vector3[] Points = {Vector3.zero, new Vector3(5, 0, 0)};
    public float PaceSpeed = 10;
    public int CurrentPoint = 0;
    public float ChaseSpeed = 20;
    [Tooltip("This value is how close to a point it should allow to count as close enough")]
    public float CloseEnough = 0.1f;
    [Tooltip("How close should the target be before chasing it.")]
    public float ChaseDist = 5;
    [Tooltip("Drag in the target object to chase. Without this object, it will only pace.")]
    public GameObject Target;
    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Check for a target.
        if(Target != null)
        {
            // Check distance to target to see whether you pace or chase
            Vector2 direction = Target.transform.position - transform.position;
            if(direction.sqrMagnitude <= ChaseDist * ChaseDist)
            {
                Chase(direction);
            }
            else
            {
                Pace();
            }
        }
        else
        {
            Pace();
        }
    }

    void Pace()
    {
        // Check if near the current point.
        Vector3 direction = Points[CurrentPoint] - transform.position;
        if(direction.magnitude <= CloseEnough * CloseEnough)
        {
            // If near, move to next
            ++CurrentPoint;
            if(CurrentPoint >= Points.Length)
            {
                CurrentPoint = 0;
            }
            direction = Points[CurrentPoint] - transform.position;
        }
        // Set the speed towards the next point.
        Vector2 acceleration = direction.normalized * PaceSpeed * Time.fixedDeltaTime;
        myRb.velocity += acceleration;
    }

    void Chase(Vector2 direction)
    {
        Vector2 acceleration = direction.normalized * ChaseSpeed * Time.fixedDeltaTime;
        myRb.velocity += acceleration;
    }
}