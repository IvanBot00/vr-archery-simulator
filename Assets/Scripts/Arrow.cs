using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float BaseSpeed = 2000.0f;
    public Transform ArrowTip = null;
    public AudioSource hitSound = null;

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
    private Vector3 LastPosition;

    private int layerMask = (1 << 7);

    private void Awake()
    {
        ArrowRB = GetComponent<Rigidbody>();
		LastPosition = ArrowTip.position;
    }

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        ArrowRB.MoveRotation(Quaternion.LookRotation(ArrowRB.velocity, transform.up));

        //detects collisions with level layer
        //currently works as long as target is not closeby
		RaycastHit hitInfo;
        if (Physics.Linecast(LastPosition, ArrowTip.position, out hitInfo, layerMask))
        {
			Transform currHit = hitInfo.transform;
            Debug.Log("Collision Detected with " + currHit.ToString());
			Debug.Log("hit at " + hitInfo.point);
            Stop();
            Destroy(gameObject, 60.0f);
        }
        LastPosition = ArrowTip.position;
    }

    private void Stop()
    {
        hitSound.Play();
        isMoving = false;
        ArrowRB.isKinematic = true;
        ArrowRB.useGravity = false;
    }

    //destroys arrows when hitting tactical target
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Tactical Targets") {
            Destroy(gameObject);
        }
    }
}
