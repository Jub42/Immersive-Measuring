using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    /// <summary>
    /// Handles the RigidBody in the Default-State.
    /// </summary>
    public class IsDefaultState : IState
    {
        public void OnEnter(StateController controller)
        {
            
        }

        public void OnExit(StateController controller)
        {
            
        }

        public void UpdateState(StateController controller)
        {
            Rigidbody rb = controller.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
