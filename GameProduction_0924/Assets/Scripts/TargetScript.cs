using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TargetScript : MonoBehaviour
{

	public int score;

	void Start()
	{
		score = 0;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider collider)
	{
		score++;

		this.transform.parent.GetComponent<TargetManager>().score++;

#if true
		this.GetComponent<Rigidbody>().useGravity = true;
		this.GetComponent<Rigidbody>().isKinematic = false;
		this.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 2.0f));
#endif
	}
}