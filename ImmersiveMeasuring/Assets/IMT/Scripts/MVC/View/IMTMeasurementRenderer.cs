using MeasurementUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class IMTMeasurementRenderer : MonoBehaviour
{
    //[SerializeField]
    //Dictionary<Measurement,GameObject> prefabMeasurements;
    public GameObject prefab;

    [SerializeField]
    Transform parent;

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

        int children = transform.childCount;
        if (children == 0) return;

        Debug.Log("möp");
        for (int i = 0; i < children; i++)
        {
            IMTDataCube dataCube = transform.GetChild(i).GetComponent<IMTDataCube>();
            Measurement measurement = new EmptyMeasurement();

            //if (dataCube.isPinned && dataCube.GetMeasurement(out measurement))
            if (dataCube.GetMeasurement(out measurement))
            {
                GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity, parent);
                go.GetComponent<IMTLine>().dataCube = dataCube;
            }
            else
            {
                Debug.Log("Measurement not available!");
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
