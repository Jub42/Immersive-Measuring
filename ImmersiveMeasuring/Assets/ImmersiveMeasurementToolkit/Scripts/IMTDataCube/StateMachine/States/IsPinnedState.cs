using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    /// <summary>
    /// Handles the RigidBody in the Pinned-State.
    /// </summary>
    public class IsPinnedState : IState
    {
        public void OnEnter(StateController controller)
        {
            Rigidbody rb = controller.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        public void OnExit(StateController controller)
        {
            
        }

        public void UpdateState(StateController controller)
        {
            Rigidbody rb = controller.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }
}

