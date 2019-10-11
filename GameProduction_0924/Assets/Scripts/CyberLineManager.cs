using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CyberLineManager : MonoBehaviour
{

	public GameObject[] linePrefab = new GameObject[6];
	public GameObject player;

	public GameObject parentObj;

	private Vector3 playerPos;
	private int existTimer;

	public const int EXIST_TIME = 20;

	bool RandBool ()
	{
		return Random.Range (0, 2) == 0;
	}

	void Start ()
	{

	}

	// カメラの視界内に入るようにランダムに生成する
	// カメラは本来プレイヤーなので360度回転する

	void Update ()
	{
		playerPos.x = player.transform.position.x;
		playerPos.y = player.transform.position.y;
		playerPos.z = player.transform.position.z;

		if (existTimer < EXIST_TIME)
			existTimer++;
		else if(parentObj)
			SpawnLine ();
		
	}

	void SpawnLine ()
	{
		//カメラから200～300ほど離れてposをとる

		Vector3 randPos = RandomPos ();
		randPos.x += Random.Range (-50.0f, 50.0f);
		randPos.z += Random.Range (-50.0f, 50.0f);

		float randPosX = randPos.x;
		float randPosY = randPos.y;
		float randPosZ = randPos.z;

		int randVal = Random.Range (0, 6);

		float radPlayer2Rand = Mathf.Atan ((randPosZ - playerPos.z) / (randPosX - playerPos.x)) * Mathf.Rad2Deg;
		GameObject childObj;
		if (randPosZ - playerPos.z > 0)
			childObj = Instantiate (linePrefab[randVal], randPos, Quaternion.Euler (0, radPlayer2Rand - 180, 90));
		else
			childObj = Instantiate (linePrefab[randVal], randPos, Quaternion.Euler (0, radPlayer2Rand, 90));

		childObj.transform.parent = parentObj.transform;


		existTimer = 0;
	}

	Vector3 RandomPos ()
	{
		float randPosX;
		float randPosZ;
		float randPosY = playerPos.y + Random.Range (150.0f, 200.0f);
		//float randPosY = playerPos.y;

#if true
		while (true)
		{
			if (RandBool ())
				randPosX = playerPos.x + Random.Range (0.0f, 300.0f);
			else
				randPosX = playerPos.x - Random.Range (0.0f, 300.0f);

			if (RandBool ())
				randPosZ = playerPos.z + Random.Range (0.0f, 300.0f);
			else
				randPosZ = playerPos.z - Random.Range (0.0f, 300.0f);

			float disXZ = Mathf.Sqrt ((randPosX - playerPos.x) * (randPosX - playerPos.x) + (randPosZ - playerPos.z) * (randPosZ - playerPos.z));

			if (disXZ >= 200.0f && disXZ <= 300.0f) break;
		}
#endif

		Vector3 randPos = new Vector3 (randPosX, randPosY, randPosZ);

		return randPos;

	}
}