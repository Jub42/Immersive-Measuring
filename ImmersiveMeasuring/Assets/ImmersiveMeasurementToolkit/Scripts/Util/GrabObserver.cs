using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// This class changes the material of the selected object, if it is grabbed.
    /// </summary>
    public class GrabObserver : MonoBehaviour
    {
        public BasicGrabbable grabbable;

        [SerializeField]
        public bool grabbed = false;

        [SerializeField]
        Material mat;
        Material baseMaterial;

        [SerializeField]
        GameObject handle;

        // Start is called before the first frame update
        void Start()
        {
            baseMaterial = handle.GetComponent<MeshRenderer>().material;
            grabbable = GetComponent<BasicGrabbable>();
        }

        // Update is called once per frame
        void Update()
        {
            grabbed = grabbable.isGrabbed;

            if (grabbed)
            {
                handle.GetComponent<MeshRenderer>().material = mat;
            }
            else
            {
                handle.GetComponent<MeshRenderer>().material = baseMaterial;
            }

        }
    }

}
