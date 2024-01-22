using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    /// <summary>
    /// Interface for States used by the StateController.
    /// </summary>
    public interface IState
    {
        public void OnEnter(StateController controller);
        public void UpdateState(StateController controller);
        public void OnExit(StateController controller);
    }
}
