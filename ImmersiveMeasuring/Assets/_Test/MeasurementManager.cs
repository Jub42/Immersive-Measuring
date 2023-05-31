using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeasurementUtility;

[RequireComponent(typeof(IMTEventHandler))]
public class MeasurementManager : MonoBehaviour
{
    [SerializeField]
    List<Measurement> measurements = new List<Measurement>(); 

    public void ImportFromJson()
    {
        // import existing list from json

        OnMeasurementsChange();
    }
    public void ExportAsJson(string path)
    {
        // export to path as json
    }

    public void CreateMeasurementObject(Measurement measurement)
    {
        // instantiate Prefab
        // add Prefab to measurements
        Debug.Log(measurement.ToJObject().ToString());

        // add measurement

        OnMeasurementsChange();
    }

    public void RemoveMeasurementObject(GameObject obj)
    {
        //measurements.Remove(obj);
        //Destroy(obj);

        OnMeasurementsChange();
    }

    void OnMeasurementsChange()
    {
        GetComponent<IMTEventHandler>().InvokeEvent();
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
