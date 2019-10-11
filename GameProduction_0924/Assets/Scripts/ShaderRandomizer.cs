using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManager : MonoBehaviour {

	// Use this for initialization
	public Material material;
	private float randomVal;
	void Start () 
	{
		//this.material = gameObject.GetComponent<Renderer>().material;
		randomVal = Random.Range(85.0f,93.0f);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.material.SetFloat("_Speed", randomVal);
	}
}
