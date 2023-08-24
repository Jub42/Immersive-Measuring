using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePointDistance2 : MonoBehaviour
{
    [SerializeField]
    Transform lineStart;
    [SerializeField]
    Transform lineEnd;
    [SerializeField]
    Transform point;

    [SerializeField]
    Transform[] trackedObjects;

    [SerializeField]
    float distance;

    [SerializeField]
    float threshold = 1.05f;

    [SerializeField]
    protected float totalDistance;

    void Update()
    {
        float distancePointStart = Vector3.Distance(point.position, lineStart.position);
        float distancePointEnd = Vector3.Distance(point.position, lineEnd.position);

        distance = Vector3.Distance(lineStart.position, lineEnd.position) * threshold;
        

        totalDistance = distancePointStart + distancePointEnd;
    }
}
