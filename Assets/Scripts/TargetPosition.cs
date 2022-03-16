using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public Vector3 m_Step = new Vector3(-5, 0, 0);

    public void IncreaseDistance()
    {
        DestroyAllArrows();
        transform.position += m_Step;
    }

    public void DecreaseDistance()
    {
        DestroyAllArrows();
        transform.position -= m_Step;
    }

    public void DestroyAllArrows()
    {
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrows");
        foreach (GameObject arrow in arrows)
        {
            Destroy(arrow);
        }
    }
}
