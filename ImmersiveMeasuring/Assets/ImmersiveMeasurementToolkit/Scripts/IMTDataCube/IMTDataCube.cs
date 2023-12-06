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
    public class IMTDataCube : StateController
    {
        public IsGrabbedState grabbedState = new IsGrabbedState();
        public IsPinnedState pinnedState = new IsPinnedState();
        public IsDefaultState defaultState = new IsDefaultState();

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            
            // if dc is grabbed
            if (GetComponent<GrabbableBase>().isGrabbed)
            {
                ChangeState(grabbedState);
            }
            // if dc is not grabbed 
            else if (currentState is not IsPinnedState)
            {
                ChangeState(defaultState);
            }
            
        }
        /// <summary>
        /// Change state to Pinned.
        /// </summary>
        public void SetPinned()
        {
            if (currentState is IsPinnedState || currentState is IsGrabbedState)
            {
                return;
            }
            else
            {
                ChangeState(pinnedState);
            }
        }
    }

}
