using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public interface IState
    {
        public void OnEnter(StateController controller);
        public void UpdateState(StateController controller);
        public void OnExit(StateController controller);
    }
}
