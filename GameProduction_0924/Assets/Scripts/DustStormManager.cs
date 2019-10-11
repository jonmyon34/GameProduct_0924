using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DustStormManager : MonoBehaviour
{

	private Transform dustStorms;
	void Start ()
	{
		//dustStorms = this.gameObject.transform.FindChild ("DustStorm");
		dustStorms = this.gameObject.transform.Find ("DustStorm");
	}

	// Update is called once per frame
	void Update ()
	{
		if (this.transform.position.y > -50.0f)
		{
			dustStorms.gameObject.SetActive (true);
		}
	}
}