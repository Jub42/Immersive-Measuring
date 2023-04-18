using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMeter : MonoBehaviour
{
    [SerializeField]
    Transform origin;

    [SerializeField]
    Transform marker;


    RaycastHit hit;
    [SerializeField]
    float distance = 10f;

    int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = new Ray(origin.position, origin.forward);

        //    if (Physics.Raycast(ray, out hit, distance, ~layerMask))
        //    {
        //        Debug.Log("Test");
        //        marker.position = hit.point;
        //        marker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        //    }
        //}

        Ray ray = new Ray(origin.position, origin.forward);

        if (Physics.Raycast(ray, out hit, distance, ~layerMask))
        {
            Debug.Log("Test");
            marker.position = hit.point;
            marker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }
}
