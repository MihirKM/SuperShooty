using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeletion : MonoBehaviour
{
    [Tooltip("Time until object is deleted."), Range(0,10)]
    public float ObjectLifetime = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeletionTimer());
    }

    IEnumerator DeletionTimer()
    {
        yield return new WaitForSeconds(ObjectLifetime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
