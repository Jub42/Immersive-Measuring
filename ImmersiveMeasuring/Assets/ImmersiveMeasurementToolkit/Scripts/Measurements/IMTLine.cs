using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using MeasurementUtility;
using DataCube;

namespace Measurements
{
    /// <summary>
    /// Handles visualization and collider of Line measurements.
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class IMTLine : MonoBehaviour, IMeasurementVisualization
    {
        // In order to render the line.
        LineRenderer lineRenderer;
        // The collider to adjust.
        CapsuleCollider collider;

        // The DataCube to get the measurement data.
        [SerializeField]
        public IMTDataCube dataCube;
        // The Measurement type to represent.
        Distance measurement;

        Vector3 lineStart;
        Vector3 lineEnd;

        [SerializeField]
        float distance;

        /// <summary>
        /// The factor which defines the length of the collider.
        /// </summary>
        [SerializeField]
        float length = 1.05f;
        /// <summary>
        /// Collider radius
        /// </summary>
        [SerializeField]
        float radius = 0.05f;
        /// <summary>
        /// Linewidth
        /// </summary>
        [SerializeField]
        float width = .025f;

        public void UpdateMeasurement(Measurement measurement)
        {
            //Get the coordinates and required components.
            Coordinate[] coords = measurement.GetCoordinates();
            Coordinate c1 = coords[0];
            Coordinate c2 = coords[1];
            lineStart = new Vector3((float)c1.x, (float)c1.y, (float)c1.z);
            lineEnd = new Vector3((float)c2.x, (float)c2.y, (float)c2.z);

            Debug.Log("lineStart: " + lineStart);
            Debug.Log("lineEnd: " + lineEnd);


            lineRenderer = GetComponent<LineRenderer>();
            collider = GetComponent<CapsuleCollider>();

            // Check if the necessary coordinates are not null
            if (lineStart == null && lineEnd == null) return;

            // Adjust lineRenderer.
            lineRenderer.widthMultiplier = width;
            lineRenderer.SetPosition(0, lineStart);
            lineRenderer.SetPosition(1, lineEnd);

            // Adjust Collider.
            Vector3 newPosition = (lineEnd + lineStart) * .5f;
            Debug.Log(lineEnd);
            Debug.Log(lineStart);
            Debug.Log(newPosition);

            collider.radius = radius;
            collider.height = length * Vector3.Distance(lineStart, lineEnd);
            collider.direction = 2; // z direction
            collider.center = Vector3.zero;
            collider.isTrigger = true;
            transform.position = newPosition;
            transform.LookAt(lineEnd);
        }

        public void ResetVisualization()
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero); // reset Line Renderer
        }

        #region Hover
        // These methods are not used in this version. 
        // The reaction to a hover event is handled by the TriggerCluster.
        public void OnHoverEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnHoverStay()
        {
            throw new System.NotImplementedException();
        }

        public void OnHoverExit()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}


