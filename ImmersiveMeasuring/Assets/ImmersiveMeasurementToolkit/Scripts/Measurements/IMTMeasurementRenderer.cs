using IMTEventSystem;
using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Measurements
{
    /// <summary>
    /// Selects an IMeasurementVisualization to set up for the corresponding 
    /// IMTMeasurementContainer.
    /// </summary>
    [RequireComponent(typeof(IMTGridItem))]
    public class IMTMeasurementRenderer : MonoBehaviour, IHoverable
    {
        IMTMeasurementContainer measurementContainer;
        IMTGridItem gridItem;
        Measurement m;

        [SerializeField]
        [Tooltip("The parent the visualization is attached to.")]
        Transform parent;

        [SerializeField]
        IMTLine line;
        // Not in use! Serves as placeholder for the corresponding arc script.
        [SerializeField]
        GameObject arc;
        // Not in use! Serves as placeholder for the corresponding area script.
        [SerializeField]
        GameObject area;

        void Start()
        {
            DeactivateVisualization();  
            gridItem = GetComponent<IMTGridItem>();
        }

        void Update()
        {
            if (!gridItem.IsOccupied)
            {
                DeactivateVisualization();
            }

#if UNITY_EDITOR
            // Editor
            if (Input.GetKeyDown("r") && gridItem.IsOccupied)
            {
                if (Render())
                {
                    Debug.Log("Rendered");
                }
            }
#endif
        }

        public void OnGridChange()
        {
            if (Render())
            {
                Debug.Log("Rendered");
            }
        }

        bool Render()
        { 
            if (gridItem.IsOccupied)
            {
                measurementContainer = gridItem.GetContent().GetComponent<IMTMeasurementContainer>();
            }
            else
            {
                return false;
            }

            m = new EmptyMeasurement();
            if (measurementContainer.GetMeasurement(out m))
            {
                Debug.Log("m: " + m);
                switch (m)
                {
                    case Distance:
                        line.GetComponent<IMTLine>().UpdateMeasurement(m);
                        line.gameObject.SetActive(true);
                        // get render data from dc
                        // setup line
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        public void OnHoverEnter()
        {
            throw new System.NotImplementedException();
        }
        public void OnHoverStay()
        {
            Debug.Log(gameObject.name + " hover.");
        }
        public void OnHoverExit()
        {
            throw new System.NotImplementedException();
        }

        void DeactivateVisualization()
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                parent.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}


