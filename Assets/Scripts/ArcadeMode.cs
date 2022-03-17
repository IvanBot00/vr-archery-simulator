using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMode : MonoBehaviour
{
    int num_targets;
    public bool game_started;
    public float time_remaining;
    public ScoringManager m_score = null;
    // Start is called before the first frame update
    void Start()
    {
        game_started = false;
        time_remaining = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        num_targets = GameObject.FindGameObjectsWithTag("Tactical Targets").Length;
        if(num_targets < 16)
        {
            game_started = true;
        }
        else
        {
            game_started = false;
        }


        if(game_started)
        {
            if(time_remaining > 0.0f)
            {
                //decrease timer
                time_remaining -= Time.deltaTime;
            }
            else
            {
                time_remaining = 0.0f;
            }
        }
        else
        {
            //if game has not started yet keep timer at 60 seconds
            time_remaining = 60.0f;
        }
    }
}
