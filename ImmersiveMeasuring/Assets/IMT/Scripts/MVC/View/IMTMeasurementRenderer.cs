using MeasurementUtility;
using System;
using UnityEngine;

public class IMTMeasurementRenderer : MonoBehaviour
{
    [SerializeField]
    //Dictionary<Measurement,GameObject> prefabMeasurements;
    GameObject prefab;
    [SerializeField]
    GameObject parentDataCubes;

    // Start is called before the first frame update
    void Start()
    {
        // Don't use!
        //prefabMeasurements.Add(Resources.Load<GameObject>("Line"));
        //Debug.Log(prefabMeasurements[0] + " Added");
    }

    // Update is called once per frame
    void Update()
    {
        // GetChildren from Pooler
        // Create corresponding render for each Measurement
        
        
    }
    void FixedUpdate()
    {

    }

    public void UpdateVisualization()
    {
        int dataCubeCount = parentDataCubes.transform.childCount;
        Debug.Log("existing DataCubes: " + dataCubeCount);

        if (this.transform.childCount != 0)
        {
            for (int i = 0; i < dataCubeCount; i++)
            {
                Debug.Log("Name: " + transform.GetChild(i).gameObject.name);
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        if (dataCubeCount != 0) 
        {
            for (int i = 0; i < dataCubeCount; i++)
            {
                IMTDataCube dataCube = parentDataCubes.transform.GetChild(i).GetComponent<IMTDataCube>();

                if (dataCube.isPinned)
                {
                    Measurement measurement = new EmptyMeasurement();

                    //if (dataCube.isPinned && dataCube.GetMeasurement(out measurement))
                    if (dataCube.GetMeasurement(out measurement))
                    {
                        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
                        go.GetComponent<IMTLine>().dataCube = dataCube;
                        go.name = dataCube.name + " | Line";
                    }
                    else
                    {
                        Debug.Log("Measurement not available!");
                    }
                } 
            }
        }   
    }

    [Serializable]
    public struct PrefabSelection
    {
        public string nameTag;
        public GameObject prefab;
    }
}
