using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("Drag object to follow here.")]
    public GameObject Target;
    [Tooltip("Set between 0 and 1 for speed."), Range(0,1)]
    public float LerpVal = 0.8f;

    float ShakeTime = 0;
    float ShakeAmount = 0;
    // Call this function to make the screen shake.
    public void TriggerShake(float time, float amount)
    {
        if(ShakeTime < time)
        {
            ShakeTime = time;
        }
        if(ShakeAmount < amount)
        {
            ShakeAmount = amount;
        }

    }    

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
        if(ShakeTime > 0)
        {
            ShakeTime -= Time.deltaTime;
            Vector3 randDir = Random.insideUnitCircle * ShakeAmount;
            transform.position += randDir;
        }
        else
        {
            ShakeAmount = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            TriggerShake(0.2f, 0.2f);
        }
    }
}
