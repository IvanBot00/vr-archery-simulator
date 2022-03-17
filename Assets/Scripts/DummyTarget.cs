using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTarget : MonoBehaviour
{
    public bool isStationary = true;
    public float speed = 1.0f;
    public Transform[] path;
    public int pathLength = 0;

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }  

    public void TurnOff()
    {
        sm.IncrementTacticalScore();
        Arrow[] arrows = GetComponentsInChildren<Arrow>();
        foreach (Arrow a in arrows)
        {
            a.Destroy();
        }
        gameObject.SetActive(false);
    }

    private ScoringManager sm = null;
    private Transform target = null;
    private int index = 0;
    private bool isReverse = false;

    void Awake()
    {
        sm = GameObject.FindObjectOfType<ScoringManager>();
        if (!isStationary)
            target = path[pathLength - 1];
    }

    void Update()
    {
        if (isStationary)
            return;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            target = path[NextIndex()];
        }
    }

    private int NextIndex()
    {
        if (isReverse)
        {
            if (index <= 0)
            {
                isReverse = false;
                ++index;
            }
            --index;
            return index; 
        }
        // Else
        ++index;
        if (index >= path.Length)
        {
            isReverse = true;
            --index;
        }
        return index;
    }
}
