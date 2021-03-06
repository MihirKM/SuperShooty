using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    private static int _score = 0;

    public static UnityEvent OnScoreChange = new UnityEvent();

    public static int Score
    {
        get
        {

            return _score;
        }
        set
        {
            _score = value;
            OnScoreChange.Invoke();
        }
    }

    private static GameManager _instance;

    public static GameManager instance
    { 
        get
        {

            return _instance;
        }
    }

    // This happens before Start, so we can only assume this exists
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
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
