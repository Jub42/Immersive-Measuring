using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Measurements;

/// <summary>
/// A script for the DataCube prefab in order to initialize it without a
/// Tool.
/// </summary>
[RequireComponent(typeof(IMTMeasurementContainer))]
public class IMTDummyCube : MonoBehaviour
{
    Distance d;

    // Start is called before the first frame update
    void Start()
    {
        d = new Distance("-1", new Coordinate(0, 0, 0), new Coordinate(0, 1, 0), 1f);
        if (GetComponent<IMTMeasurementContainer>().SetMeasurement(d))
        {
            Debug.Log("Set to DummyCube");
        }
    }
}
