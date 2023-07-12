using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject go;

    [SerializeField]
    Transform spawnLocation;

    [SerializeField]
    Transform parent;

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
        //Instantiate(go, Vector3.zero, Quaternion.identity, parent);
        //TODO: naming
        GameObject prefab = Instantiate(go, spawnLocation.position, Quaternion.identity, parent);
        prefab.GetComponent<IMTDataCube>().isPinned = true;

        if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
        {
            Debug.Log("DataCube spawned: " + prefab.name);
        }
    }
}
