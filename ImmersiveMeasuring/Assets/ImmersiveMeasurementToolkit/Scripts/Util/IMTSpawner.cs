using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class IMTSpawner : MonoBehaviour
    {
        [SerializeField]
        IMTObjectPooler pooler;

        public void SpawnObject(Measurement m)
        {
            // create DataCube
            // add DC to Pool
            pooler.AddObject(null);
        }
    }
}

