using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [Tooltip("Amount of damage.")]
    public int Amount = 4;
    [Tooltip("Destroy object on collision. (Useful for projectiles!)")]
    public bool DestroyOnCollide = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collided");
        // Make sure there is a health component.
        Health h = collision.gameObject.GetComponent<Health>();
        if(h != null)
        {
            print("Health exists");
            h.ChangeHealth(-Amount);
        }
        if(DestroyOnCollide)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Make sure there is a health component.
        Health h = collision.gameObject.GetComponent<Health>();
        if (h != null)
        {
            h.ChangeHealth(-Amount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make sure there is a health component.
        Health h = collision.GetComponent<Health>();
        if (h != null)
        {
            h.ChangeHealth(-Amount);
        }
        if (DestroyOnCollide)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Make sure there is a health component.
        Health h = collision.GetComponent<Health>();
        if (h != null)
        {
            h.ChangeHealth(-Amount);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
