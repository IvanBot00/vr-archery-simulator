using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    public GameObject ArrowPrefab = null;

    [Header("Bow")]
    public float GrabThreshold = 0.15f;
    public Transform StartPoint = null;
    public Transform EndPoint = null;
    public Transform Socket = null; // Location of the place where the arrow snaps to the bow

    private Transform PullingHand = null;
    private Arrow CurrentArrow = null;
    private Animator BowAnimator = null;
    private float PullValue = 0.0f;

    public void PullBowString(Transform hand)
    {
        float distance = Vector3.Distance(hand.position, StartPoint.position);

        // Debug.Log(distance);

        if (distance > GrabThreshold)
            return;

        PullingHand = hand;
    }

    public void ReleaseBowString()
    {
        if (PullValue > 0.25f)
            FireArrow();

        PullingHand = null;
        PullValue = 0.0f;
        BowAnimator.SetFloat("Blend", 0);

        if (!CurrentArrow)
            StartCoroutine(CreateArrow(0.25f));
    }

    private void Awake()
    {
        BowAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0.0f));
    }

    private void Update()
    {
        if (!PullingHand || !CurrentArrow)
            return;

        PullValue = CalculatePull(PullingHand);
        PullValue = Mathf.Clamp(PullValue, 0.0f, 1.0f);

        Debug.Log("Setting float to " + PullValue);

        BowAnimator.SetFloat("Blend", PullValue);
    }

    private float CalculatePull(Transform pullHand)
    {
        Vector3 direction = EndPoint.position - StartPoint.position;
        
        direction.Normalize();

        Vector3 difference = pullHand.position - StartPoint.position;

        return Vector3.Dot(difference, direction) / direction.magnitude;
    }

    private void FireArrow()
    {
        CurrentArrow = null;
    }

    private IEnumerator CreateArrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject arrowObject = Instantiate(ArrowPrefab, Socket);

        arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObject.transform.localEulerAngles = Vector3.zero;

        CurrentArrow = arrowObject.GetComponent<Arrow>();
    }
}
