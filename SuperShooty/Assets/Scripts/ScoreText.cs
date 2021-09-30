using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    SfxrSynth synth = new SfxrSynth();
    public string ScoreSound;
    TMP_Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<TMP_Text>();
        ChangeText();
        GameManager.OnScoreChange.AddListener(ChangeText);
        synth.parameters.SetSettingsString(ScoreSound);
    }

    public void ChangeText()
    {
        Score.text = "Score: " + GameManager.Score;
        synth.Play();
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
