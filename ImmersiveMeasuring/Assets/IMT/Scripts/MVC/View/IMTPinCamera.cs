using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTPinCamera : MonoBehaviour
{
    [SerializeField]
    Transform camera;

    [SerializeField]
    GameObject display;

    [SerializeField]
    Transform originMarker;

    [SerializeField]
    Transform targetMarker;

    [SerializeField]
    float cameraOffset = .5f;

    [SerializeField]
    float threshold = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = (originMarker.position - targetMarker.position).normalized * cameraOffset;    
        camera.position = targetMarker.position + offset;
        camera.LookAt(targetMarker.position);

        Debug.DrawLine(targetMarker.position, targetMarker.position + offset, Color.blue);

        if (Vector3.Distance(originMarker.position, targetMarker.position) > threshold)
        {
            display.SetActive(true);
        }
        else
        {
            display.SetActive(false);
        }
    }

}
