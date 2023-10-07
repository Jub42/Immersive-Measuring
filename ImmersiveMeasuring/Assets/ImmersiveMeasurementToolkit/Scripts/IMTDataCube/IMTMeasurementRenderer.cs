using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataCube
{
    [RequireComponent(typeof(IMTMeasurementContainer))]
    public class IMTMeasurementRenderer : MonoBehaviour
    {
        IMTMeasurementContainer measurementContainer;

        [SerializeField]
        [Tooltip("Selection of prefabs for corresponding Measurements.")]
        List<GameObject> prefabs = new List<GameObject>();

        void Start()
        {
            measurementContainer = GetComponent<IMTMeasurementContainer>();
        }

        void Update()
        {
            //check type
            // update
        }

        void CreateRender()
        {
            
        }

        void OnHover()
        {

        }


    }
}


