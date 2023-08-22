using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTPinCamera : MonoBehaviour
{
    [SerializeField]
    Camera camera;

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
        //transform.position = ;
        transform.LookAt(targetMarker.position);

        //Debug.DrawLine();

        if (Vector3.Distance(originMarker.position, targetMarker.position) > threshold)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
