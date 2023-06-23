using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeasurementUtility;

// Just for Import/Export ?
public class MeasurementManager : MonoBehaviour
{
    List<Measurement> measurements = new List<Measurement>(); 

    public List<Measurement> Measurements { get { return measurements; } }

    [SerializeField]
    GameEvent gameEvent;

    //public IMTList<Measurement> measurements = new IMTList<Measurement>();

    public void ImportFromJson()
    {
        // import existing data from json

        OnMeasurementsChange();
    }
    public void ExportAsJson(string path)
    {
        // export to path as json
    }

    // GetInfo()


    // Deprecated? if pinned variant
    public void AddMeasurement(Measurement measurement)
    {
        // instantiate Prefab
        // add Prefab to measurements
        Debug.Log("###### " + measurement.ToJson());

        // add measurement
        measurements.Add(measurement);
        Debug.Log(measurements.Count);
        OnMeasurementsChange();
    }

    public void RemoveMeasurement(Measurement measurement)
    {
        Debug.Log("Delete: " + measurement.ToJson());
        measurements.Remove(measurement);
        Debug.Log(measurements.Count);
        OnMeasurementsChange();
    }

    void OnMeasurementsChange()
    {
        //GetComponent<IMTEventHandler>().InvokeEvent();
    }

    // Save Coroutine

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(visualize) update data
        // else hide?

        
    }
}
