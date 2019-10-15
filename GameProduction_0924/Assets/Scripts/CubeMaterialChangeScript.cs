using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CubeMaterialChangeScript : MonoBehaviour
{

	public Material[] materials = new Material[2];

	private int i = 0;
	private float duration = 0.0f;
	private bool stopFlg = false;

	const float WAIT_TIME = 4.0f; //second

	public bool DEBUG = false;

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		ChangeMaterial();
	}

	void ChangeMaterial()
	{
		if (this.transform.position.y <= 0.0f && !stopFlg)
		{
			{
				// if (i == 0)
				// 	i++;
				// else if (i == 1)
				// 	i--;

				i = i ^ 1;
				
			}

			this.GetComponent<Renderer>().material = materials[i];

			{
				this.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
				this.GetComponent<Rigidbody>().useGravity = false;
			}
			stopFlg = true;

		}

		if (duration < WAIT_TIME && stopFlg)
		{
			duration += Time.deltaTime;
		}
		else if (duration >= WAIT_TIME)
		{
			if (DEBUG)
			{
				Vector3 pos = this.transform.position;
				pos.y = WAIT_TIME;
				this.transform.position = pos;
				duration = 0.0f;
				this.GetComponent<Rigidbody>().useGravity = true;
				stopFlg = false;
			}
			else
				Destroy(this.gameObject);
		}
	}
}