using HTC.UnityPlugin.Vive;
using MeasurementUtility;
using UnityEngine;
using IMTEventSystem;
using Util;

namespace Tools
{
    /// <summary>
    /// Creates the Measurement.
    /// </summary>
    public class IMTLaserRangeFinder : MonoBehaviour
    {
        TwoPointDistanceMeasure tool = new TwoPointDistanceMeasure("Distance Measure");

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
        void Update()
        {
            if ((ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger) && GetComponent<GrabObserver>().grabbed) || Input.GetKeyDown("space"))
            {
                Coordinate[] c = {
                new Coordinate(originMarker.position.x, originMarker.position.y, originMarker.position.z),
                new Coordinate(targetMarker.position.x, targetMarker.position.y, targetMarker.position.z)};
                // Use MeasurementUtility to update the Measurement.
                tool.Measure(IMTIDHandler.GetID(), c);
                // Get the Measurement.
                Measurement m = tool.CreateMeasurement();

                Debug.Log(m);

                onMeasure.TriggerEvent(m);
            }
        }
    }
}