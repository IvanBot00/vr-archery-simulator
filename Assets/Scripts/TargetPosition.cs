using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public Vector3 m_Step = new Vector3(-5, 0, 0);

    public void IncreaseDistance()
    {
        transform.position += m_Step;
    }

    public void DecreaseDistance()
    {
        transform.position -= m_Step;
    }
}
