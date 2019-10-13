using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTargetScript : MonoBehaviour
{

	public Text scoreText;
	public int score = 0;

	Vector3 pos0 = new Vector3(0.0f,-90.0f,-6.0f);
	Vector3 rota0 = new Vector3(0.0f,0.0f,0.0f);

	Vector3 pos1 = new Vector3(6.0f,-90.0f,0.0f);
	Vector3 rota1 = new Vector3(0.0f,90.0f,0.0f);

	Vector3 pos2 = new Vector3(0.0f,-86.0f,0.0f);
	Vector3 rota2 = new Vector3(90.0f,0.0f,0.0f);

	public bool plMoveFlg = false;

	

	void Start ()
	{

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

			switch(score)
			{
				case 1:
					this.transform.position = pos1;
					this.transform.rotation = Quaternion.Euler(rota1);

					break;

				case 2:
					this.transform.position = pos2;
					this.transform.rotation = Quaternion.Euler(rota2);

					break;

				case 3:
				/*
					this.transform.position = pos0;
					this.transform.rotation = Quaternion.Euler(rota0);

					ここで本来消滅エフェクトと一緒になんかして最初に戻す
				*/
					plMoveFlg = true;
					
					break;

				default:
					break;
			}

		}
	}

}