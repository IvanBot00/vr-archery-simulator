using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    public int current_score;
    public int tactical_score;
    public int high_score;
    // Start is called before the first frame update
    void Start()
    {
        current_score = 0;
        tactical_score = 0;
        if(PlayerPrefs.HasKey("HighScore")) {
            high_score = PlayerPrefs.GetInt("HighScore");
        }
    }

    void Update()
    {
        if (tactical_score > high_score) {
            high_score = current_score;
        }
    }

    string DisplayRangeScore()
    {
        string out_string;
        out_string = "Current Score: ";
        out_string = out_string + current_score;
        return out_string;
    }

    string DisplayTacticalScore()
    {
        string out_string;
        out_string = "Current Score: ";
        out_string = out_string + tactical_score;
        return out_string;
    }
}
