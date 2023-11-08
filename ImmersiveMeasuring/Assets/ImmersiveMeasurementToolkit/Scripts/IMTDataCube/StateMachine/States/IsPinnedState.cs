using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class IsPinnedState : IState
    {
        public void OnEnter(DataCubeStateController controller)
        {
            Rigidbody rb = controller.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        public void OnExit(DataCubeStateController controller)
        {
            
        }

        public void UpdateState(DataCubeStateController controller)
        {
            Rigidbody rb = controller.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }
}

