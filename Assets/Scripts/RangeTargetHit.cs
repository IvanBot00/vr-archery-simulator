using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTargetHit : MonoBehaviour
{
    public ScoringManager m_score = null;
    //public AudioClip m_hit_sound = null;
    //public AudioSource m_audio = null;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision) {
        //Determine distance from center and increment m_score.current_score
        //based off distance

        Debug.Log("Range Target Hit");

        //m_audio.clip = m_hit_sound;
        //m_audio.Play();

        m_score.current_score++;
    }
}
