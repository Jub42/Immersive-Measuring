using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeasurementUtility;

public class MeasurementManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> measurements = new List<GameObject>(); 

    public void ImportFromJson()
    {
        // import existing list from json
    }
    public void ExportAsJson(string path)
    {
        // export to path as json
    }

    public void CreateMeasurementObject(Measurement measurement)
    {
        // instantiate Prefab
        // add Prefab to measurements
    }

    public void RemoveMeasurementObject(GameObject obj)
    {
        measurements.Remove(obj);
        Destroy(obj);
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
