using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class moveFlgChecker : MonoBehaviour
{

	private GameObject _child;
	public bool playerMoveFlg = false; //１度目の移動フラグ
	public bool playerMoveFlg2 = false; //２度目の移動フラグ


	private Vector3 traningRoomFirstScale;	//リスタート用

	

	public GameObject SecondRoomMoveCheck;

	/*
		thisのscaleが0になったら1回目のプレイヤーフラグがtrue

		チュートリアルルームで的に矢が3回当たったときに２回目が動き出す		
	*/

	void Start ()
	{
		traningRoomFirstScale = this.transform.localScale;
	}

	// Update is called once per frame
	void Update ()
	{
		playerMoveFlg2 = SecondRoomMoveCheck.GetComponent<TutorialTargetScript> ().plMoveFlg;
		//tutorialでスコアが3になったら向こうのフラグがtrueになってそれがこっちに来る


		Vector3 scaleCheck = this.gameObject.transform.localScale;
		if (scaleCheck.x == 0.0f) //scaleが0になったら
		{
			//ここでFlgを立ててplayerMover辺りに渡す？
			//Destroy (this.gameObject);
			playerMoveFlg = true;
		}

	}
}