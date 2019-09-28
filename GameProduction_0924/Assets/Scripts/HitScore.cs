using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitScore : MonoBehaviour 
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

	public void AddScore(int point)
	{
		score += point;
	}
}
