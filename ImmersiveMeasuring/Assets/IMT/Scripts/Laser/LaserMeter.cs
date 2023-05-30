using UnityEngine;
using TMPro;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;

public class LaserMeter : MonoBehaviour
{
    [SerializeField]
    Transform origin;

    [SerializeField]
    Transform marker;

    [SerializeField]
    float distance;

    RaycastHit hit;
    [SerializeField]
    float rayCastDistance = 10f;

    int layerMask;

    [SerializeField]
    TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(origin.position, marker.position);
        display.text = distance.ToString();

        if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
        {
            // Hook for Button // central definition point

            // do something
            // create new distance!
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
            Debug.Log(hit.triangleIndex);
            marker.position = hit.point;
            marker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }
}
