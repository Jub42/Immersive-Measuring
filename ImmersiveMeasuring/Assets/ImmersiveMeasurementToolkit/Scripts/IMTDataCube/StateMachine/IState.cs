using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public interface IState
    {
        public void OnEnter(DataCubeStateController controller);
        public void UpdateState(DataCubeStateController controller);
        public void OnExit(DataCubeStateController controller);
    }
}
