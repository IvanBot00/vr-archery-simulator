using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Bow m_Bow = null;
    public GameObject m_OppositeController = null;
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
        {
            m_Bow.PullBowString(m_OppositeController.transform);
            // Debug.Log("Button Pressed");
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
        {
            m_Bow.ReleaseBowString();
        }
    }
}
