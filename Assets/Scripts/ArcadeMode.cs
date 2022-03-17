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
        num_targets = GameObject.FindGameObjectsWithTag("DummyTarget").Length;
    }

    // Update is called once per frame
    void Update()
    {
        int new_num_targets = GameObject.FindGameObjectsWithTag("DummyTarget").Length;
        if(new_num_targets < num_targets)
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
