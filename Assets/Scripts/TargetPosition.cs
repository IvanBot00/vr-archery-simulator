using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    private Vector3 m_Step = new Vector3(5, 0, 0);

    public void IncreaseDistance()
    {
        if(this.transform.position[0] < 17.0f) {
            DestroyAllArrows();
            transform.position += m_Step;
        }
    }

    public void DecreaseDistance()
    {
        if(this.transform.position[0] > -8.0f) {
            DestroyAllArrows();
            transform.position -= m_Step;
        }
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
