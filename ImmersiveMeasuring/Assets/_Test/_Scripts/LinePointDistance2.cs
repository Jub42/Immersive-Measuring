using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePointDistance2 : MonoBehaviour
{
    [SerializeField]
    Transform lineStart;
    [SerializeField]
    Transform lineEnd;

    // exchange for trackedObjects
    [SerializeField]
    Transform point;

    [SerializeField]
    Transform[] trackedObjects;

    float interactionDistance;

    [SerializeField]
    float threshold = 1.05f;

    [SerializeField]
    bool inRange = false;

    protected float totalDistance;

    void Update()
    {
        // for(int i = 0; i < trackedObjects.Length; i++) check distance

        float distancePointStart = Vector3.Distance(point.position, lineStart.position);
        float distancePointEnd = Vector3.Distance(point.position, lineEnd.position);

        interactionDistance = Vector3.Distance(lineStart.position, lineEnd.position) * threshold;
        
        totalDistance = distancePointStart + distancePointEnd;
    }
    void FixedUpdate()
    {
        if (totalDistance < interactionDistance)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    public void AssignTracker(Transform obj)
    {
        point = obj;
    }
}
