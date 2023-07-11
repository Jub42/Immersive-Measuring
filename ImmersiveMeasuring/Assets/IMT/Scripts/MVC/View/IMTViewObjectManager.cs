using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Visualize Measurements as DataCubes
/// </summary>
public class IMTViewObjectManager : MonoBehaviour
{
    [SerializeField]
    MeasurementStorage storage;
    [SerializeField]
    GameObject go;
    [SerializeField]
    Transform spawnLocation;

    List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // measurement in scene not data cube
    public void CreateDataCube(Measurement m)
    {
        GameObject prefab = Instantiate(go, spawnLocation.position, Quaternion.identity);
        if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
        {
            objects.Add(prefab);
        }
        Debug.Log(storage.Count);
    }
    // for now: clear and refresh
    public void UpdateVisualization()
    {
        objects.Clear();
        for(int i = 0; i < storage.Count; i++)
        {
            CreateDataCube(storage.GetValue(i));
        }
    }

    // Delete Cube and Measurement
}
