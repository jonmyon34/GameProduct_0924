using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour {
	public int lifeTime;
	// Use this for initialization
	void Start () {
		lifeTime = 120;
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime--;
		if (lifeTime < 0)
			Destroy (this.gameObject);
	}
}
