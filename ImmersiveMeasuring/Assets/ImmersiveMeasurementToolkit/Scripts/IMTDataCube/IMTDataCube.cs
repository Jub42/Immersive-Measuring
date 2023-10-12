using HTC.UnityPlugin.Vive;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Util;

namespace DataCube
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class IMTDataCube : DataCubeStateController
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

            if (GetComponent<GrabbableBase>().isGrabbed)
            {
                ChangeState(grabbedState);
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            // if other GridItem
            // it other Controller
            //ChangeState(pinnedState);
        }
        private void OnTriggerExit(Collider other)
        {
            
        }
    }

}
