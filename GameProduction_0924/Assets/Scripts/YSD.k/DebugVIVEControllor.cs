using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;
public class DebugVIVEControllor : MonoBehaviour
{
    public bool LhandTrigger;
    public bool RhandTrigger;
    public bool LhandGrab;
    public bool RhandGrab;
    public int pad;

    public bool LhandTriggerUp;
    public bool LhandTriggerDawn;
    public bool LhandTriggerLast;
    public bool LhandTriggerLastUp;
    public bool LhandTriggerLastDawn;
    public bool RhandTriggerUp;
    public bool RhandTriggerDawn;
    public bool RhandTriggerLast;
    public bool RhandTriggerLastUp;
    public bool RhandTriggerLastDawn;

    public bool LhandGrabUp;
    public bool LhandGrabDawn;
    public bool LhandGrabLast;
    public bool LhandGrabLastUp;
    public bool LhandGrabLastDawn;
    public bool RhandGrabUp;
    public bool RhandGrabDawn;
    public bool RhandGrabLast;
    public bool RhandGrabLastUp;
    public bool RhandGrabLastDawn;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LhandGrab = InputVIVEController.LhandGrab;
        LhandTrigger = InputVIVEController.LhandTrigger;
        LhandTriggerUp= InputVIVEController.LhandTriggerUp;
        LhandTriggerDawn = InputVIVEController.LhandTriggerDawn;
        LhandTriggerLast = InputVIVEController.LhandTriggerLast;
        LhandTriggerLastUp = InputVIVEController.LhandTriggerLastUp;
        LhandTriggerLastDawn = InputVIVEController.LhandTriggerLastDawn;
        LhandGrabUp = InputVIVEController.LhandGrabUp;
        LhandGrabDawn = InputVIVEController.LhandGrabDawn;
        LhandGrabLast = InputVIVEController.LhandGrabLast;
        LhandGrabLastUp = InputVIVEController.LhandGrabLastUp;
        LhandGrabLastDawn = InputVIVEController.LhandGrabLastDawn;


        RhandGrab = InputVIVEController.RhandGrab;
        RhandTrigger = InputVIVEController.RhandTrigger;
        RhandTriggerUp = InputVIVEController.RhandTriggerUp;
        RhandTriggerDawn = InputVIVEController.RhandTriggerDawn;
        RhandTriggerLast = InputVIVEController.RhandTriggerLast;
        RhandTriggerLastUp = InputVIVEController.RhandTriggerLastUp;
        RhandTriggerLastDawn = InputVIVEController.RhandTriggerLastDawn;
        RhandGrabUp = InputVIVEController.RhandGrabUp;
        RhandGrabDawn = InputVIVEController.RhandGrabDawn;
        RhandGrabLast = InputVIVEController.RhandGrabLast;
        RhandGrabLastUp = InputVIVEController.RhandGrabLastUp;
        RhandGrabLastDawn = InputVIVEController.RhandGrabLastDawn;

    }
};
