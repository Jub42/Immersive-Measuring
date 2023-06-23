using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTBin : MonoBehaviour
{
    [SerializeField]
    MeasurementGameEvent OnDelete;

    Measurement m;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            OnDelete.TriggerEvent(m);
        }
    }

    public void AddMeasurement(Measurement m)
    {
        this.m = m;
    }
}
