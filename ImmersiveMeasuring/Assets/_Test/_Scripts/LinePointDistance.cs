using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePointDistance : MonoBehaviour
{
    [SerializeField]
    Transform lineStart;
    [SerializeField]
    Transform lineEnd;
    [SerializeField]
    Transform point;

    [SerializeField]
    protected float distance;

    void Update()
    {
        Vector3 a = Difference(point.position, lineStart.position);
        Vector3 vectorProduct = Vectorproduct(a, lineEnd.position);
        distance = Norm(vectorProduct) / Norm(lineEnd.position);
    }

    Vector3 Vectorproduct(Vector3 a, Vector3 b)
    {
        Vector3 d;

        d.x = a.y * b.z - a.z * b.y;
        d.y = a.z * b.x - a.x * b.z;
        d.z = a.x * b.y - a.y * b.x;

        return d;
    }

    Vector3 Difference(Vector3 a, Vector3 b)
    {
        Vector3 d;

        return d = a - b;
    }

    float Norm(Vector3 a)
    {
        return Mathf.Sqrt((a.x * a.x) + (a.y * a.y) + (a.z * a.z));
    }
}
