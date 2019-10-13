using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBugManager : MonoBehaviour
{

	// Use this for initialization
	public GameObject player;
	private Vector3 plFirstPos;

	public Material material;
	const float INC_TIMES_VAL = 1.05f;
	private float alpha = 0.01f;
	private float grid;

	private bool resetFlg = false;

	const float ANIMSTART_PL_POS = -210.0f;

	const float GRID_MIN = 10.0f;
	const float GRID_MAX = 10000.0f;
	const float ALPHA_MIN = 0.0f;
	const float ALPHA_MAX = 1.0f;

	/*
		処理

		プレイヤーが-210.0fを超えたらバグシェーダーのアルファを弄りだす
		アルファが0.7を超えたらグリッド線を増やし始める

		プレイヤーがｰ100を超えたらアルファとグリッドを初期値に戻す（リスタート用に）

		プレイヤーがｰ50を超えたらフラグを戻す（リスタートとif文を通らなくする用に）

		プレイヤーが初期位置にいる場合、一度だけマテリアルの値を初期値に戻す（デバッグ兼リスタート用）
	*/

	void Start ()
	{
		grid = material.GetFloat ("_Grid");
		plFirstPos = player.transform.position;
	}

	void Update ()
	{
		if (player.transform.position.y < -100.0f)
		{
			if (player.transform.position.y >= ANIMSTART_PL_POS)
			{
				material.SetFloat ("_Alpha", alpha);

				if (alpha < ALPHA_MAX)
					alpha *= INC_TIMES_VAL;
				else if (alpha > ALPHA_MAX)
					alpha = ALPHA_MAX;
			}
			if (alpha >= 0.7f)
			{
				if (grid < GRID_MAX)
					grid *= INC_TIMES_VAL;
				else if (grid > GRID_MAX)
					grid = GRID_MAX;

				material.SetFloat ("_Grid", grid);
			}
		}

		if (!resetFlg && player.transform.position.y >= -100.0f && player.transform.position.y <= -50.0f)
		{
			material.SetFloat ("_Alpha", ALPHA_MIN);
			material.SetFloat ("_Grid", GRID_MIN);
			resetFlg = true;
		}

		if(player.transform.position.y >= -50.0f)
			resetFlg = false;

		if(!resetFlg && player.transform.position == plFirstPos)
		{
			material.SetFloat ("_Alpha", ALPHA_MIN);
			material.SetFloat ("_Grid", GRID_MIN);
			resetFlg = true;
		}

	}

}