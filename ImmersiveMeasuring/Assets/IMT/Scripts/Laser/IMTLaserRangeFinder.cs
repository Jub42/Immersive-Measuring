using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTLaserRangeFinder : MonoBehaviour
{
    [SerializeField]
    Transform originMarker;
    [SerializeField]
    Transform targetMarker;

    [SerializeField]
    MeasurementGameEvent onMeasure;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger) && GetComponent<GrabObserver>().grabbed)
        {

        }
    }
}
