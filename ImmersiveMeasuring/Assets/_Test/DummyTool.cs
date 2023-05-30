using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMTEventHandler))]
public class DummyTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Coordinate c1 = new Coordinate(0,0,0);
        Coordinate c2 = new Coordinate(1,0,0);
        Distance d = new Distance("1", c1, c2, 1f);

        GetComponent<IMTEventHandler>().InvokeEvent(d);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
