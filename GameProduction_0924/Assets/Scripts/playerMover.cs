using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class playerMover : MonoBehaviour
{

	GameObject moveStarter;
	moveFlgChecker script;

	private Transform playerPos;
	private Vector3 tmpPos;

	public float speedX;
	public float speedY;
	public float speedZ;

	bool startFlg = false;
	bool startFlg2 = false;

	bool stopFirstFlg = false;
	bool stopSecondFlg = false;

	public float stopPosY = -100.0f;

	public bool debugFlg = false;

	void Start ()
	{
		playerPos = this.transform;

		//GameObjectのスクリプト内のFlgを取得してそれ次第でどうこうする
		moveStarter = GameObject.Find ("TraningRooms"); //オブジェクト名
		script = moveStarter.GetComponent<moveFlgChecker> ();
		//そもそもGameObjectが存在してるかどうかをチェックしてやったほうがいい？
	}

	// Update is called once per frame
	void Update ()
	{

		if (startFlg || startFlg2 || debugFlg)
		{
			tmpPos = playerPos.position;

			tmpPos.x += speedX;
			tmpPos.y += speedY;
			tmpPos.z += speedZ;

			playerPos.position = tmpPos;

			if (playerPos.position.y >= stopPosY) //止める用に（2部屋目の真ん中あたりまで来たら）
			{
				startFlg = false;
				//このままだと下のelseの部分でまたFlgがtrueになるので別の方法も考えるべきかもしれない
				stopFirstFlg = true;
			}
		}
		else if (!stopFirstFlg)
		{
			startFlg = script.playerMoveFlg; //moveStarter内のFlgを取得
		}
		else if(!stopSecondFlg)
		{
			startFlg2 = script.playerMoveFlg2;	
		}
	}

}