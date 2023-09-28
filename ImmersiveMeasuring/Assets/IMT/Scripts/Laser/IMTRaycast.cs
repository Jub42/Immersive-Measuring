using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTRaycast : MonoBehaviour
{
    [SerializeField]
    Transform originMarker;
    [SerializeField]
    Transform targetMarker;

    
    [SerializeField]
    float rayCastDistance;

    [SerializeField]
    LayerMask excludedLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(originMarker.position, originMarker.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayCastDistance, ~excludedLayers))
        {
            targetMarker.position = hit.point;
            targetMarker.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        else
        {
            Debug.DrawRay(originMarker.position, originMarker.TransformDirection(Vector3.forward) * 1000, Color.red, 2f);
            Debug.Log("Did not Hit");
        }
    }
}
