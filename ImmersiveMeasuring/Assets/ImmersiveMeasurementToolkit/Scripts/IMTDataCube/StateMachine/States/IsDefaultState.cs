using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class IsDefaultState : IState
    {
        public void OnEnter(DataCubeStateController controller)
        {
            
        }

        public void OnExit(DataCubeStateController controller)
        {
            
        }

        public void UpdateState(DataCubeStateController controller)
        {
            Rigidbody rb = controller.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
