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

		float startTime = 0;
		const int DESTROY_TIME = 5; //second

		const float SHRINKING_VAL_PER_FRAME = 0.985f; //縮小させる割合の定数

		public GameObject startButton;

		void Start ()
		{
		}

		void Update ()
		{
			startFlg = startButton.GetComponent<TraningButton> ().playerMoveFlg;
			//ここをキーボード入力からトリガー入力に切り替える
			//if (Input.GetKeyDown (KeyCode.DownArrow))
			if (startFlg)
			{
				shrinkFlg = true;
				if (!timeGotFlg)
				{
					startTime = Time.time;
					timeGotFlg = true;
				}
			}

#if true
			if (shrinkFlg)
			{
				foreach (Transform child in transform) //全子にアクセス
				{
					Transform tmp = child.gameObject.transform;
					Vector3 size = child.gameObject.transform.localScale;

					//size.x *= SHRINKING_VAL_PER_FRAME;
					size.y *= SHRINKING_VAL_PER_FRAME;
					//size.z *= SHRINKING_VAL_PER_FRAME;		//XとZは部屋ごと縮小されるから消す（実際はどの軸かは知らない）

					tmp.localScale = size;
					//startTime += Time.deltaTime;
					if (Time.time - startTime > DESTROY_TIME)
					//if (startTime > DESTROY_TIME)
					{
						//destroyFlg = true;
						Destroy (child.gameObject);
						shrinkFlg = false;
					}
				}
			}
#endif

			if (destroyFlg)
				Destroy (this.gameObject);

		}

	}
}