using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//34check

public class ArrowTargetMove : MonoBehaviour {



	public Text scoreText;
	private int score;

	private Vector3 firstPos;
	private Vector3 pos;

	private bool minusMove = false;


	void Start () 
	{
		firstPos = transform.localPosition;
		pos = firstPos;
		score = 0;	
	}
	
	void Update () 
	{
		move();


		scoreText.text = score.ToString();
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "projectile")
		{
			score += 2;
		}
	}

	void move()
	{
		if(!minusMove)
		{
			transform.localPosition = pos;
			pos.x += 0.05f;
			if(firstPos.x - pos.x <-10.0f)
			{
				minusMove = true;
			}
		}
		else
		{
			transform.localPosition = pos;
			pos.x -= 0.05f;
			if(firstPos.x - pos.x > 10.0f)
			{
				minusMove = false;
			}

		}


	}

}
