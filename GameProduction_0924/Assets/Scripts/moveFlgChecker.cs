using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class moveFlgChecker : MonoBehaviour
{

	private GameObject _child;
	public bool playerMoveFlg = false; //１度目の移動フラグ
	public bool playerMoveFlg2 = false; //２度目の移動フラグ

	private int checkScore = 0;

	public GameObject SecondRoomMoveCheck;

	/*
	private bool moveFlg = false;
		これを別スクリプトから参照しておくとか
	*/

	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		checkScore = SecondRoomMoveCheck.GetComponent<ArrowTargetEight> ().score;
		if (this.gameObject.transform.childCount == 0) //子がすべて無くなったら
		{
			//ここでFlgを立ててplayerMover辺りに渡す？
			//Destroy (this.gameObject);
			playerMoveFlg = true;
		}

		if (checkScore == 3)
		{
			playerMoveFlg2 = true;
			//チュートリアルルームで的に矢が3回当たったときに２回目が動き出す
		}
	}
}