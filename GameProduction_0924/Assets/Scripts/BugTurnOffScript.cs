using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BugTurnOffScript : MonoBehaviour
{

	private Vector3 scale;
	
	public bool debugMode = false;	//デバッグ、調整用
	public bool resetFlg = false;	//デバッグ、調整用

	private float duration = 0.0f;
	private float timesVal = 1.0f;

	public float decScaleY = 0.195f;
	public float decTimesScaleX = 0.91f;

	private Vector3 firstScale;

	/*
		現状フラグをインスペクターから立てることのみで動作するのでそれをプレイヤーの位置次第でどうこうするようにする
	*/

	public GameObject player;
	const float TURN_OFF_PL_POS = 0.0f;

	void Start()
	{
		scale = this.transform.localScale;
		firstScale = scale;
	}

	// Update is called once per frame
	void Update()
	{
		if (debugMode)
		{
			if (duration <= 0.2f)
			{
				timesVal += Time.deltaTime;
				scale.y *= timesVal * timesVal;
				scale.x *= decTimesScaleX;
			}
			else if (duration > 0.2f && scale.y > 0.0f)
			{
				scale.y -= decScaleY;
				scale.x *= decTimesScaleX;
			}
			if (scale.y <= 0.0f)
			{
				scale.y = 0.0f;
				scale = new Vector3(0.0f, 0.0f, 0.0f);
				this.transform.localScale = scale;
			}
			duration += Time.deltaTime;

			this.transform.localScale = scale;

			if (resetFlg)
			{
				debugMode = false;
				resetFlg = false;
				scale = firstScale;
				duration = 0.0f;
				this.transform.localScale = firstScale;
				timesVal = 1.0f;
			}

		}
	}
}