using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMTEventHandler))]
public class DummyTool : MonoBehaviour
{
    Coordinate c1 = new Coordinate(0, 0, 0);
    Coordinate c2 = new Coordinate(1, 0, 0);
    Distance d;

    // Start is called before the first frame update
    void Start()
    {
        d = new Distance("1", c1, c2, 1f);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {

        }
        if (Input.GetKeyDown("s"))
        {

        }
    }
}
