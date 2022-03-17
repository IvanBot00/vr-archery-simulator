using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTargetHit : MonoBehaviour
{
    public ScoringManager m_score = null;
    private float zone4 = 0.4f;
    private float zone3 = 0.3f;
    private float zone2 = 0.2f;
    private float zone1 = 0.1f;
    //public AudioClip m_hit_sound = null;
    //public AudioSource m_audio = null;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision) {
        //Determine distance from center and increment m_score.current_score
        //based off distance
        int hit_score = 0;
        Debug.Log("Range Target Hit");

        Vector3 hit_position = collision.GetContact(0).point;
        float dist = Vector3.Distance(hit_position, transform.position);
        Debug.Log("Collision at distance: " + dist);

        if(dist > zone4) {
            hit_score = 1;
        }
        else if(dist > zone3) {
            hit_score = 2;
        }
        else if(dist > zone2) {
            hit_score = 3;
        }
        else if(dist > zone1) {
            hit_score = 4;
        }
        else {
            hit_score = 5;
        }
        //m_audio.clip = m_hit_sound;
        //m_audio.Play();
        m_score.current_score = hit_score;
    }
}
