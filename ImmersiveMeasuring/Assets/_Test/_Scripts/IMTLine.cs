using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using MeasurementUtility;
using Newtonsoft.Json.Linq;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(CapsuleCollider))]
public class IMTLine : MonoBehaviour, IMeasurementVisualization
{
    LineRenderer lineRenderer;
    CapsuleCollider collider;

    [SerializeField]
    public IMTDataCube dataCube;
    Distance measurement;

    [SerializeField]
    Vector3 lineStart;
    [SerializeField]
    Vector3 lineEnd;

    [SerializeField]
    float distance;

    [SerializeField]
    float length = 1.05f;
    [SerializeField]
    float radius = 0.05f;
    [SerializeField]
    float width = .025f;

    public void UpdateMeasurement(Measurement measurement)
    {
        Coordinate[] coords = measurement.GetCoordinates();
        Coordinate c1 = coords[0];
        Coordinate c2 = coords[1];
        lineStart = new Vector3((float)c1.x, (float)c1.y, (float)c1.z);
        lineEnd = new Vector3((float)c2.x, (float)c2.y, (float)c2.z);

        Debug.Log("lineStart: " + lineStart);
        Debug.Log("lineEnd: " + lineEnd);


        lineRenderer = GetComponent<LineRenderer>();
        collider = GetComponent<CapsuleCollider>();

        if (lineStart == null && lineEnd == null) return;

        lineRenderer.widthMultiplier = width;
        lineRenderer.SetPosition(0, lineStart);
        lineRenderer.SetPosition(1, lineEnd);

        Vector3 newPosition = (lineEnd + lineStart) * .5f;
        Debug.Log(lineEnd);
        Debug.Log(lineStart);
        Debug.Log(newPosition);

        collider.radius = radius;
        collider.height = length * Vector3.Distance(lineStart, lineEnd);
        collider.direction = 2; // z direction
        collider.center = Vector3.zero;
        collider.isTrigger = true;
        transform.position = newPosition;
        transform.LookAt(lineEnd);

        // place Pins ?
    }

    public void OnHoverEnter()
    {
        throw new System.NotImplementedException();
    }
    public void OnHoverStay()
    {
        throw new System.NotImplementedException();
    }
    public void OnHoverExit()
    {
        throw new System.NotImplementedException();
    }
}
