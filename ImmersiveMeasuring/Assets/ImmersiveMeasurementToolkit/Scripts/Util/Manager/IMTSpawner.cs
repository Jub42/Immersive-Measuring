using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// This class creates a DataCube and adds it to an IMTObjectPooler. 
    /// </summary>
    public class IMTSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject imtObjectPooler;
        IMTObjectPooler imtPooler;

        [SerializeField]
        GameObject goDataCube;

        [SerializeField]
        Transform spawnLocationDataCube;

        private void Start()
        {
            imtPooler = imtObjectPooler.GetComponent<IMTObjectPooler>();
        }

        private void Update()
        {
            
        }

        public void SpawnObject(Measurement m)
        {

            GameObject prefab = Instantiate(goDataCube, spawnLocationDataCube.position, Quaternion.identity);
            if (IMTObjectCreationTool.InstantiateMeasurementOnGameObj(m, ref prefab))
            {
                prefab.name = m.ID;
                Debug.Log("DataCube spawned: " + m.GetType() + " " + prefab.name);
            }
            // create DataCube
            // add DC to Pool
            imtPooler.AddObject(prefab);
        }
    }
}

