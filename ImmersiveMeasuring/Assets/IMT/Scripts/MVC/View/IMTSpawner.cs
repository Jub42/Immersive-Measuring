using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class IMTSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject go;

    [SerializeField]
    Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDataCube(Measurement m)
    {
        GameObject prefab = Instantiate(go, spawnLocation.position, Quaternion.identity);
        
        if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
        {
            Debug.Log("DataCube spawned: " + prefab.name);
        }
    }
}
