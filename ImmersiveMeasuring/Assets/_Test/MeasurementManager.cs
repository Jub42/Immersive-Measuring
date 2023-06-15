using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeasurementUtility;

//TODO: Singleton

//[RequireComponent(typeof(IMTEventHandler))]
public class MeasurementManager : MonoBehaviour
{
    private List<Measurement> measurements = new List<Measurement>(); 

    public List<Measurement> Measurements{get { return measurements; }}

    [SerializeField]
    GameEvent gameEvent;

    //public IMTList<Measurement> measurements = new IMTList<Measurement>();

    public void ImportFromJson()
    {
        // import existing list from json

        OnMeasurementsChange();
    }
    public void ExportAsJson(string path)
    {
        // export to path as json
    }

    // GetInfo()

    public void CreateMeasurementObject(Measurement measurement)
    {
        // instantiate Prefab
        // add Prefab to measurements
        Debug.Log("###### " + measurement.ToJObject().ToString());

        // add measurement
        measurements.Add(measurement);
        Debug.Log(measurements.Count);
        OnMeasurementsChange();
    }

    public void RemoveMeasurementObject(Measurement measurement)
    {
        Debug.Log("Delete: " + measurement.ToJObject().ToString());
        measurements.Remove(measurement);
        Debug.Log(measurements.Count);
        OnMeasurementsChange();
    }

    void OnMeasurementsChange()
    {
        //GetComponent<IMTEventHandler>().InvokeEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(visualize) update list
        // else hide?

        
    }
}
