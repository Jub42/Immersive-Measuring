using UnityEngine;
using TMPro;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using MeasurementUtility;

[RequireComponent(typeof(LineRenderer))]
public class LaserMeter : MonoBehaviour
{
    [SerializeField]
    MeasurementGameEvent onMeasure;

    [SerializeField]
    Transform originMarker;

    [SerializeField]
    Transform targetMarker;

    LineRenderer lineRenderer;
    [SerializeField]
    float lineWidth = .025f;

    protected float distance;

    RaycastHit hit;
    [SerializeField]
    float rayCastDistance;

    [SerializeField]
    LayerMask excludedLayers;

    [SerializeField]
    TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.SetPosition(0, originMarker.position);
        lineRenderer.SetPosition(1, targetMarker.position);

        distance = Vector3.Distance(originMarker.position, targetMarker.position);
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
                new Coordinate(originMarker.position.x, originMarker.position.y, originMarker.position.z),
                new Coordinate(targetMarker.position.x, targetMarker.position.y, targetMarker.position.z),
                distance);

            onMeasure.TriggerEvent(m);
        }
    }

    void FixedUpdate()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = new Ray(originMarker.position, originMarker.forward);

        //    if (Physics.Raycast(ray, out hit, rayCastDistance, ~layerMask))
        //    {
        //        Debug.Log("Test");
        //        targetMarker.position = hit.point;
        //        targetMarker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        //    }
        //}

        Ray ray = new Ray(originMarker.position, originMarker.forward);

        if (Physics.Raycast(ray, out hit, rayCastDistance, ~excludedLayers))
        {
            targetMarker.position = hit.point;
            targetMarker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        
    }
}
