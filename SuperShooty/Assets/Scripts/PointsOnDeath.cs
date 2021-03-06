using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnDeath : MonoBehaviour
{
    [Tooltip("Points that are added to the score in the game manager when dying.")]
    public int Points = 5;
    // Start is called before the first frame update
    void Start()
    {
        Death Grim = GetComponent<Death>();
        Grim.OnDeath.AddListener(AddPoints);
    }

    public void AddPoints()
    {
        GameManager.Score += Points;
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
