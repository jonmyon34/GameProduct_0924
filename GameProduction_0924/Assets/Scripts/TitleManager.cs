using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

	// Use this for initialization
	public GameObject player;




	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		if(player.transform.position.y >= -230.0f)
		{
			//タイトルのマテリアルのアルファをここで0から増やす
			//TitleBugManagerの方でやってもいいかもしれない
		}
	}
}