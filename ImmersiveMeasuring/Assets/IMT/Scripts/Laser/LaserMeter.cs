using UnityEngine;
using TMPro;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using MeasurementUtility;

public class LaserMeter : MonoBehaviour
{
    [SerializeField]
    MeasurementGameEvent onMeasure;

    [SerializeField]
    Transform origin;

    [SerializeField]
    Transform marker;

    [SerializeField]
    protected float distance;

    RaycastHit hit;
    [SerializeField]
    float rayCastDistance = 10f;

    [SerializeField]
    int[] excludedLayers;
    int layerMask;

    [SerializeField]
    TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < excludedLayers.Length; i++)
        {
            layerMask &= 1 << excludedLayers[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(origin.position, marker.position);
        //display.text = interactionDistance.ToString();

        // Check for isGrabbed

        // location + button pressed
        if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.PadTouch))
        {
            display.text = "padAxis = " + ViveInput.GetPadAxisEx(HandRole.RightHand); // location
        }

        //if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger) && GetComponent<GrabObserver>().grabbed)
        if (Input.GetKeyDown("space"))
        {
            // Hook for Button // central definition point

            // do something
            // create new interactionDistance!
            //Measurement m1 = Formulary.CalculateDistance(string, Coord, Coord);
            Measurement m = new Distance(IMTIDHandler.GetID(), 
                new Coordinate(origin.position.x, origin.position.y, origin.position.z),
                new Coordinate(marker.position.x, marker.position.y, marker.position.z),
                distance);

            onMeasure.TriggerEvent(m);
        }
    }

    void FixedUpdate()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = new Ray(origin.position, origin.forward);

        //    if (Physics.Raycast(ray, out hit, rayCastDistance, ~layerMask))
        //    {
        //        Debug.Log("Test");
        //        marker.position = hit.point;
        //        marker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        //    }
        //}

        Ray ray = new Ray(origin.position, origin.forward);

        if (Physics.Raycast(ray, out hit, rayCastDistance, ~layerMask))
        {
            marker.position = hit.point;
            marker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        else
        {
            marker.position = origin.position;
        }
    }
}
