using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTManager : MonoBehaviour
{
    [SerializeField]
    MeasurementStorage storage;

    #region deprecated?
    [SerializeField]
    GameObject go;

    [SerializeField]
    Transform spawnLocation;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    {
        int children = transform.childCount;
        for(int i = 0; i < children; i++)
        {
            IMTDataCube dataCube = transform.GetChild(i).GetComponent<IMTDataCube>();
            if (dataCube.isPinned)
            {
                Measurement m = new EmptyMeasurement();
                if (dataCube.GetMeasurement(out m))
                {
                    storage.AddData(m);
                }
            }
        }
        Debug.Log("Storage Count: " + storage.Count);
    }

    // Coroutines? / Async
    public void ImportFromJson()
    {
        // import existing data from json to DataStorage
    }
    public void ExportAsJson(string path)
    {
        // export pinned DataCube information to path as json
    }

    // Create and add DataCube
    public void AddDataCube(Measurement m)
    {
        //GameObject prefab = Instantiate(go, spawnLocation.position, Quaternion.identity);
        //if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
        //{
            //storage.AddData(go);
        //}
        //Debug.Log(storage.Count);
    }
}
