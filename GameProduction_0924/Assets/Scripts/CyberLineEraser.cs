using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CyberLineEraser : MonoBehaviour
{

	public GameObject player;
	private bool existFlg;

	void Start ()
	{
		existFlg = true;
	}

	// プレイヤーが一定座標を超える or 何かしらのフラグが立った時に消す
	// 綺麗なプレイヤーのフラグの参照の仕方が思いつかない

	void Update ()
	{
		if (!existFlg)
			Destroy (this.gameObject);
		else
		{
			if (player.transform.position.y > -100.0f)
				existFlg = false;
		}
	}
}