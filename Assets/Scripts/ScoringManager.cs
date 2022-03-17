using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringManager : MonoBehaviour
{
    public Text scoreboard;
    public int current_score;
    public int tactical_score;
    public int high_score;
    public Transform camera;
    private bool in_range;
    
    public void IncrementTacticalScore()
    {
        ++tactical_score;
    }

    void Start()
    {
        current_score = 0;
        tactical_score = 0;

        if(PlayerPrefs.HasKey("HighScore")) {
            high_score = PlayerPrefs.GetInt("HighScore");
        }

        in_range = true;
    }

    void Update()
    {
        if(camera.position[0] <= -9.0f) {
            in_range = false;
        }
        else {
            in_range = true;
        }

        if (tactical_score > high_score) {
            high_score = tactical_score;
        }

        if(in_range) {
            scoreboard.text = DisplayRangeScore();
        }
        else {
            scoreboard.text = DisplayTacticalScore();
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
