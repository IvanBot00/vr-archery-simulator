using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHolder : MonoBehaviour
{
    public void Reset()
    {
        foreach (DummyTarget d in dummies)
        {
            d.TurnOn();
        }
    }

    private DummyTarget[] dummies;

    void Start()
    {
        dummies = FindObjectsOfType<DummyTarget>();
    }
}
