using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject goDataCube;

    [SerializeField]
    Transform spawnLocationDataCube;

    [SerializeField]
    Transform parentDataCube;

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
        //Instantiate(goDataCube, Vector3.zero, Quaternion.identity, parentDataCube);
        GameObject prefab = Instantiate(goDataCube, spawnLocationDataCube.position, Quaternion.identity, parentDataCube);
        prefab.GetComponent<IMTDataCube>().isPinned = false;

        if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
        {
            prefab.name = m.ID;
            Debug.Log("DataCube spawned: " + m.GetType() + " " + prefab.name);
        }
    }
}
