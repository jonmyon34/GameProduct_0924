using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SecondRoomDoorManager : MonoBehaviour
{

	public GameObject player;
	public AudioClip clip1;
	private AudioSource audioSource;
	private Transform playerPos;

	private Vector3 tmpScale;

	const float INC_TIME_VAL = 1.008f;
	const float DEC_TIME_VAL = 0.992f;

	const float CONST_SCALE = 0.47f;

	const float START_OPEN_PL_POS_Y = -160.0f;

	void Start ()
	{
		playerPos = player.transform;
		tmpScale = this.transform.localScale;
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = clip1;
	}

	// Update is called once per frame
	void Update ()
	{
		if (this.transform.localScale.x == 0.0f && playerPos.position.y > START_OPEN_PL_POS_Y) //playerPos.y>-100.0f
		{
			tmpScale = this.transform.localScale;
			tmpScale.x += 0.001f;
			tmpScale.z += 0.001f;
		}

		if (this.transform.localScale.x < CONST_SCALE && playerPos.position.y < -90.0f)
		{
			tmpScale.x *= INC_TIME_VAL;
			tmpScale.z *= INC_TIME_VAL;

			this.transform.localScale = tmpScale;
		}
		else if (this.transform.localScale.x > CONST_SCALE)
		{
			tmpScale.x = CONST_SCALE;
			tmpScale.z = CONST_SCALE;

			this.transform.localScale = tmpScale;
		}

		if (this.transform.localScale.x > 0.2&&this.transform.localScale.x < 0.3)
		{
			audioSource.PlayOneShot (clip1);
		}

		if (playerPos.position.y > -90.0f)
		{
			tmpScale.x *= DEC_TIME_VAL;
			tmpScale.z *= DEC_TIME_VAL;

			this.transform.localScale = tmpScale;
		}

	}
}