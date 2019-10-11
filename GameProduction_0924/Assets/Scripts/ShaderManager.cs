using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderRandomizer : MonoBehaviour {

	// Use this for initialization
	public Material material_0;
	public Material material_1;
	public Material material_2;
	public Material material_3;
	public Material material_4;
	public Material material_5;
	private float randomVal;
	void Start () 
	{
		//this.material = gameObject.GetComponent<Renderer>().material;
		this.material_0.SetFloat("_Speed", Random.Range(80.0f,93.0f));
		this.material_1.SetFloat("_Speed", Random.Range(80.0f,93.0f));
		this.material_2.SetFloat("_Speed", Random.Range(80.0f,93.0f));
		this.material_3.SetFloat("_Speed", Random.Range(80.0f,93.0f));
		this.material_4.SetFloat("_Speed", Random.Range(80.0f,93.0f));
		this.material_5.SetFloat("_Speed", Random.Range(80.0f,93.0f));
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
