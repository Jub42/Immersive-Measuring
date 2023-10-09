using MeasurementUtility;
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
        [Tooltip("The parent the visualization is attached to.")]
        Transform parent;

        [SerializeField]
        IMTLine line;
        [SerializeField]
        GameObject arc;
        [SerializeField]
        GameObject area;

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
            for(int i = 0; i < parent.childCount; i++)
            {
                parent.GetChild(i).gameObject.SetActive(false);
            }

            Measurement m = new EmptyMeasurement();
            if (measurementContainer.GetMeasurement(out m))
            {
                switch (m)
                {
                    case Distance:
                        line.gameObject.SetActive(true);
                        // get render data from dc
                        // setup line
                        break;
                    default:
                        break;
                }
            }
            
        }

        void OnHover()
        {

        }


    }
}


