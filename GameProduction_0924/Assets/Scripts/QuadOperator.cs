using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
	public class QuadOperator : MonoBehaviour
	{

		// Use this for initialization

		bool destroyFlg = false;
		bool shrinkFlg = false;
		bool timeGotFlg = false;

		bool startFlg = false;

		public bool debugFlg = false;

		float startTime = 0;
		const int DESTROY_TIME = 5; //second

		const float SHRINKING_VAL_PER_FRAME = 0.985f; //縮小させる割合の定数

		public GameObject startButton;

		public GameObject player;


		private Vector3 thisScale;		//リスタート用
		private Vector3 childScale0;	//リスタート用
		private Vector3 childScale1;	//リスタート用
		private Vector3 childScale2;	//リスタート用
		private Vector3 childScale3;	//リスタート用

		/*
			リスタートの際にこれらの変数内の値をそれぞれに戻す
		*/

		void Start ()
		{
			thisScale = this.transform.localScale;
			childScale0 = this.transform.GetChild(0).transform.localScale;
			childScale1 = this.transform.GetChild(1).transform.localScale;
			childScale2 = this.transform.GetChild(2).transform.localScale;
			childScale3 = this.transform.GetChild(3).transform.localScale;
		}


		void Update ()
		{
			startFlg = startButton.GetComponent<TraningButton> ().playerMoveFlg;
			//ここをキーボード入力からトリガー入力に切り替える
			//if (Input.GetKeyDown (KeyCode.DownArrow))
			if (startFlg || debugFlg)
			{
				shrinkFlg = true;
				if (!timeGotFlg)
				{
					startTime = Time.time;
					timeGotFlg = true;
				}
			}

			if (shrinkFlg)
			{
				foreach (Transform child in transform) //全子にアクセス
				{
					Transform tmp = child.gameObject.transform;
					Vector3 size = child.gameObject.transform.localScale;

					//size.x *= SHRINKING_VAL_PER_FRAME;
					size.y *= SHRINKING_VAL_PER_FRAME;
					//size.z *= SHRINKING_VAL_PER_FRAME;		//XとZは部屋ごと縮小されるから除外

					tmp.localScale = size;
					//startTime += Time.deltaTime;
					if (Time.time - startTime > DESTROY_TIME)
					//if (startTime > DESTROY_TIME)
					{
						destroyFlg = true;
						//Destroy (child.gameObject);
						shrinkFlg = false;
					}
				}
			}

			if (destroyFlg)
			{
				Vector3 scale0 = new Vector3(0.0f,0.0f,0.0f);
				this.transform.localScale = scale0;
			}



			if(player.transform.position.y >= -200.0f)
			{
				this.transform.localScale = thisScale;
				this.transform.GetChild(0).transform.localScale = childScale0;
				this.transform.GetChild(1).transform.localScale = childScale1;
				this.transform.GetChild(2).transform.localScale = childScale2;
				this.transform.GetChild(3).transform.localScale = childScale3;	
			}


		}

	}
}