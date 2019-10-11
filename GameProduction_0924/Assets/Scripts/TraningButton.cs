using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
	public class TraningButton : MonoBehaviour
	{

		public bool playerMoveFlg = false;
		private bool hoverFlg = false;

		// Use this for initialization
		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{
			if (hoverFlg && (InputVIVEController.LhandTrigger || InputVIVEController.RhandTrigger))
			{
				playerMoveFlg = true;
			}
		}

		void OnHandHoverStay (Hand hand) { }

		void OnHandHoverBegin (Hand hand)
		{
			hoverFlg = true;
		}

		void OnHandHoverEnd (Hand hand)
		{
			hoverFlg = false;
		}

	}
}