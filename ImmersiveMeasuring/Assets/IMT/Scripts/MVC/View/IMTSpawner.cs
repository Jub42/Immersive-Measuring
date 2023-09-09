using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject goDataCube;

    [SerializeField]
    Transform spawnLocation;

    [SerializeField]
    Transform parentDataCube;

    [SerializeField]
    Transform parentVisualization;

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
        //TODO: Parent
        //Instantiate(goDataCube, Vector3.zero, Quaternion.identity, parentDataCube);
        //TODO: naming
        GameObject prefab = Instantiate(goDataCube, spawnLocation.position, Quaternion.identity, parentDataCube);
        prefab.GetComponent<IMTDataCube>().isPinned = false;

        if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
        {
            prefab.name = m.ID;
            Debug.Log("DataCube spawned: " + m.GetType() + " " + prefab.name);
        }
    }

    public void SpawnVisualization()
    {
        // create Vis in corresponding pooler
    }
}
