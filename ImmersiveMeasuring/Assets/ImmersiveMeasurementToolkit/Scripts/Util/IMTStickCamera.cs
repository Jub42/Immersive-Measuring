using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// This class positions a GameObject serving as display and
    /// a camera which projects an image onto this plane.
    /// Should be used independed from MeasurementUtility dll so 
    /// the Unity native Vector3.Distance is used.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class IMTStickCamera : MonoBehaviour
    {
        // Camera and settings.
        Camera camera;
        [SerializeField]
        float nearClipPlane;
        [SerializeField]
        float depth = -1;

        [SerializeField]
        [Tooltip("The observed target.")]
        Transform target;
        // The GameObject serving as display.
        [SerializeField]
        Transform display;
        // The designated position for the display.
        [SerializeField]
        Transform displayPosition;
        [SerializeField]
        Vector3 cameraOffset;
        [SerializeField]
        float cameraDistanceToTarget;
        [SerializeField]
        [Tooltip("The display is visible from a distance of [Activation Threshold] meters.")]
        float activationThreshold = 3f;

        // Start is called before the first frame update
        void Start()
        {
            camera = GetComponent<Camera>();
            camera.nearClipPlane = nearClipPlane;
            camera.depth = depth;
        }

        // Update is called once per frame
        void Update()
        {
            // Place camera.
            Vector3 offset = (display.position - target.position).normalized * cameraDistanceToTarget;
            camera.transform.position = target.position + offset + cameraOffset;
            camera.transform.LookAt(target.position);

            Debug.DrawLine(target.position, target.position + offset + cameraOffset, Color.blue);

            // Activate or deactivate the display
            if (Vector3.Distance(display.position, target.position) > activationThreshold)
            {
                display.gameObject.SetActive(true);
            }
            else
            {
                display.gameObject.SetActive(false);
            }

            display.position = displayPosition.position;
        }
        void SetCameraOffset(Vector3 offset)
        {
            cameraOffset = offset;
        }
    }

}