using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMTDataCube))]    
public class IMTDummyCube : MonoBehaviour
{
    Distance d;

    // Start is called before the first frame update
    void Start()
    {
        d = new Distance("-1", new Coordinate(0, 0, 0), new Coordinate(0, 1, 0), 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (GetComponent<IMTDataCube>().SetMeasurement(d))
        {
            Debug.Log("Set to DummyCube");
        }

    }
}
