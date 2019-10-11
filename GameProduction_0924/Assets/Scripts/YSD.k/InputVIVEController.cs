using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//注意！！　このスクリプトをアタッチしたオブジェクトは一番最初のシーンに設置してください

public class InputVIVEController : MonoBehaviour
{
    public SteamVR_Action_Boolean grabpinchAction;
    public SteamVR_Action_Boolean grabgripAction;
    public SteamVR_Action_Vibration vibration;

    public static SteamVR_Input_Sources Lhand = SteamVR_Input_Sources.LeftHand;
    public static SteamVR_Input_Sources Rhand = SteamVR_Input_Sources.RightHand;//要テスト

    public static bool LhandTrigger;
    public static bool LhandTriggerUp;
    public static bool LhandTriggerDawn;
    public static bool LhandTriggerLast;
    public static bool LhandTriggerLastUp;
    public static bool LhandTriggerLastDawn;
    public static bool RhandTrigger;
    public static bool RhandTriggerUp;
    public static bool RhandTriggerDawn;
    public static bool RhandTriggerLast;
    public static bool RhandTriggerLastUp;
    public static bool RhandTriggerLastDawn;

    public static bool LhandGrab;
    public static bool LhandGrabUp;
    public static bool LhandGrabDawn;
    public static bool LhandGrabLast;
    public static bool LhandGrabLastUp;
    public static bool LhandGrabLastDawn;
    public static bool RhandGrab;
    public static bool RhandGrabUp;
    public static bool RhandGrabDawn;
    public static bool RhandGrabLast;
    public static bool RhandGrabLastUp;
    public static bool RhandGrabLastDawn;


    private
    // Use this for initialization
    void Start()
    {
        //シーンが切り替わってもアタッチされているオブジェクトが破棄されないはず
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////////////////
        //          左 手         //
        ///////////////////////////
        //手のひらボタン
        LhandGrab = grabgripAction.GetState(Lhand);
        LhandGrabUp = grabgripAction.GetStateUp(Lhand);
        LhandGrabDawn = grabgripAction.GetStateDown(Lhand);
        LhandGrabLast = grabgripAction.GetLastState(Lhand);
        LhandGrabLastUp = grabgripAction.GetLastStateUp(Lhand);
        LhandGrabDawn = grabgripAction.GetLastStateDown(Lhand);
        //人差し指トリガー
        LhandTrigger = grabpinchAction.GetState(Lhand);
        LhandTriggerUp = grabpinchAction.GetStateUp(Lhand);
        LhandTriggerDawn = grabpinchAction.GetStateDown(Lhand);
        LhandTriggerLast = grabpinchAction.GetLastState(Lhand);
        LhandTriggerLastUp = grabpinchAction.GetLastStateUp(Lhand);
        LhandTriggerLastDawn = grabpinchAction.GetLastStateDown(Lhand);

        ///////////////////////////
        //          右 手         //
        ///////////////////////////
        //手のひらボタン
        RhandGrab = grabgripAction.GetState(Rhand);
        RhandGrabUp = grabgripAction.GetStateUp(Rhand);
        RhandGrabDawn = grabgripAction.GetStateDown(Rhand);
        RhandGrabLast = grabgripAction.GetLastState(Rhand);
        RhandGrabLastUp = grabgripAction.GetLastStateUp(Rhand);
        RhandGrabDawn = grabgripAction.GetLastStateDown(Rhand);
        //人差し指トリガー
        RhandTrigger = grabpinchAction.GetState(Rhand);
        RhandTriggerUp = grabpinchAction.GetStateUp(Rhand);
        RhandTriggerDawn = grabpinchAction.GetStateDown(Rhand);
        RhandTriggerLast = grabpinchAction.GetLastState(Rhand);
        RhandTriggerLastUp = grabpinchAction.GetLastStateUp(Rhand);
        RhandTriggerLastDawn = grabpinchAction.GetLastStateDown(Rhand);


        //vibration.Execute(,,,,);//何秒後に、何秒間、何Hzで、どれくらいの強さで、どの機器をバイブレーション
    }
    public static bool GetLhandTriggerState()
    {
        return LhandTrigger;
    }
}
