using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float BaseSpeed = 2000.0f;
    public Transform ArrowTip = null;

    public void Fire(float pullValue)
    {
        isMoving = true;
        transform.parent = null;

        ArrowRB.isKinematic = false;
        ArrowRB.useGravity = true;
        ArrowRB.AddForce(transform.forward * (pullValue * BaseSpeed));
    }

    private Rigidbody ArrowRB = null;
    private bool isMoving = false;
    private Vector3 LastPosition = Vector3.zero;

    private int layerMask = (1 << 7);

    private void Awake()
    {
        ArrowRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        ArrowRB.MoveRotation(Quaternion.LookRotation(ArrowRB.velocity, transform.up));

        //detects collisions with level layer
        //currently works as long as target is not closeby
        if (Physics.Linecast(LastPosition, ArrowTip.position, layerMask))
        {
            Debug.Log("Collision Detected");
            Stop();
            Destroy(gameObject, 120.0f);
        }
        LastPosition = ArrowTip.position;
    }

    private void Stop()
    {
        isMoving = false;
        ArrowRB.isKinematic = true;
        ArrowRB.useGravity = false;
    }
}
