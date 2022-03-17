using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalTarget : MonoBehaviour
{
	public float velocity;
	public bool x_direction;
	public bool isStationary;
    private Vector3 initRotation;
	private float initYPosition;
	public ScoringManager m_score = null;
	// Start is called before the first frame update
    void Start()
    {
        velocity = 1.0f;
		initRotation = transform.localEulerAngles;
		initYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
		transform.localEulerAngles = initRotation;
		if (!isStationary)
		{
			transform.position = new Vector3(transform.position.x, initYPosition, transform.position.z);
			if(x_direction)
			{
				transform.Translate(velocity * Time.deltaTime, 0, 0);
			}
			else
			{
				transform.Translate(0, 0, velocity * Time.deltaTime);
			}
		}
	}

	void OnCollisionEnter(Collision collision) {

		if(collision.gameObject.tag != "Arrow")
		{
			velocity = -velocity;
		}
		else
		{
			m_score.tactical_score += 1;
			//Debug.Log("Score: " + m_score.tactical_score);
			this.gameObject.SetActive(false);
		}

	}

}
