using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    [RequireComponent(typeof(Interactable))]

    public class ScriptPushButton : MonoBehaviour
    {
        public string Scene_Change_to ;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnHandHoverBegin(Hand hand)
        {
            if (InputVIVEController.LhandTrigger == true || InputVIVEController.RhandTrigger == true)
            {
                Debug.Log("ボタンが押されましたBegin");
            }
        }

        void OnHandHoverEnd(Hand hand)
        {
            //if (InputVIVEController.LhandTrigger == true || InputVIVEController.RhandTrigger == true)
            {
                Debug.Log("ボタンが押されましたEnd");
            }

        }
    }

}


