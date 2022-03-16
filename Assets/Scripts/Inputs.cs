using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Bow m_Bow = null;
    public ScoringManager m_Score = null;
    public GameObject m_OppositeController = null;
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;
    public GameObject m_Target = null;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
        {
            m_Bow.PullBowString(m_OppositeController.transform);
            // Debug.Log("Button Pressed");
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
        {
            m_Bow.ReleaseBowString();
        }

        // Target Control
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            m_Target.GetComponent<TargetPosition>().DecreaseDistance();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            m_Target.GetComponent<TargetPosition>().IncreaseDistance();
        }

        //Scoring Reset
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
			Debug.Log("B button pressed");
            m_Score.current_score = 0;
			m_Score.tactical_score = 0;
			
			//resetting targets still not working
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Tactical Targets");
            foreach (GameObject target in targets) {
				Debug.Log("Current target: " + target.ToString());
                target.SetActive(true);
            }
        }

        if(OVRInput.GetDown(OVRInput.RawButton.Start)) {
            //exit and save score (?)
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                PlayerPrefs.SetInt("HighScore", m_Score.high_score);
                Application.Quit();
            #endif
        }
    }
}
