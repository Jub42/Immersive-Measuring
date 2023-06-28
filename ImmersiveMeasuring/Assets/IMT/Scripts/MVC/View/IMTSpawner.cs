using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class IMTSpawner : MonoBehaviour
{
    [SerializeField]
    List <GameObject> objects = new List <GameObject> ();

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

    public void AddDataCube(Measurement m)
    {
        GameObject prefab = Instantiate(go, spawnLocation.position, Quaternion.identity);
        if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
        {
            objects.Add(prefab);
        }
    }
    public void RemoveDataCube(GameObject obj)
    {
        objects.Remove(obj);
    }
}
