using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTool : MonoBehaviour
{
    [SerializeField]
    MeasurementGameEvent e;
    [SerializeField]
    MeasurementGameEvent e2;
    
    Coordinate c1 = new Coordinate(0, 0, 0);
    Coordinate c2 = new Coordinate(1, 0, 0);
    Distance d;

    // Start is called before the first frame update
    void Start()
    {
        d = new Distance("1", c1, c2, 1f);

        e.TriggerEvent(d);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            e.TriggerEvent(d);
        }
        if (Input.GetKeyDown("s"))
        {
            e2.TriggerEvent(d);
        }
    }
}
