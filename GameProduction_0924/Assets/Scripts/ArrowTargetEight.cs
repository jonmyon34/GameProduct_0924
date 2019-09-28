using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//34check

public class ArrowTargetEight : MonoBehaviour 
{


	public Text scoreText;
	private int score;

	void Start () 
	{
		score = 0;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreText.text = score.ToString();
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "projectile")
		{
			score++;
		}
	}


}
