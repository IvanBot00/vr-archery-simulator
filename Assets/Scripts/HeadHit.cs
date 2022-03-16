using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHit : MonoBehaviour
{
    public ScoringManager m_score = null;
	private Transform parent = null;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("body hit");
		m_score.tactical_score += 3;
		parent.gameObject.SetActive(false);
	}
}
