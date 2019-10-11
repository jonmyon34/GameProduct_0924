using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManagerScript : MonoBehaviour {
	public int rng;
	public GameObject obj;
	public Material[] mtl;
	Vector3 vec;
	Quaternion qua;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rng = Random.Range (0, 101);
		if (rng <= 1) {
			vec.x = Random.Range (-10, 10);
			vec.y = Random.Range (0, 100);
			vec.z = Random.Range (-13, -3);
			qua.x = vec.x;
			qua.y = vec.y;
			qua.z = vec.z;
			if (rng==0) {
				obj.GetComponent<Renderer> ().sharedMaterial = mtl[0];
			}
			else if (rng==1) {
				obj.GetComponent<Renderer> ().sharedMaterial = mtl[1];
			}
			Instantiate (obj, vec, qua);
		}
	}
}
