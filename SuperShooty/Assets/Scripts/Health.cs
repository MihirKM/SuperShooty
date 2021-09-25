using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Starting health of the object.")]
    public int CurrentHealth = 20;
    [Tooltip("Maximum health of the object.")]
    public int MaxHealth = 20;
    [Tooltip("Destroy the object at 0 health.")]
    public bool DestroyAtZero = true;
    [Tooltip("Time in seconds the object is invulerable after damage.")]
    public float InvulTime = 0.3f;
    float InvulTimer = 0;
    float DestructionTime = 0.2f;

    public void ChangeHealth(int amount)
    {
        // Check if the change is damage, and if so, check if invincible.
        if (amount >= 0 || InvulTimer <= 0)
        {
            CurrentHealth += amount;
            if (amount < 0)
            {
                InvulTimer = InvulTime;
            }
        }
        // If reduced to 0, and object must be destroyed, do so.
        if (CurrentHealth <= 0 && DestroyAtZero)
        {
            StartCoroutine(TimedDestruction());
        }
        // Correct health if over max.
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    IEnumerator TimedDestruction()
    {
        yield return new WaitForSeconds(DestructionTime);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InvulTimer > 0)
        {
            InvulTimer -= Time.deltaTime;
        }
    }
}