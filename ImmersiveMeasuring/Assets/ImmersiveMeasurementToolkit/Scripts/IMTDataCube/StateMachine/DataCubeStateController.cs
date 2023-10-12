using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class DataCubeStateController : MonoBehaviour
    {
        protected IState currentState;
        public IState CurrentState { get { return currentState; } }

        public IsGrabbedState grabbedState = new IsGrabbedState();
        public IsPinnedState pinnedState = new IsPinnedState();
        public IsDefaultState defaultState = new IsDefaultState();

        // Start is called before the first frame update
        protected virtual void Start()
        {
            ChangeState(defaultState);
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateState(this);
            }
        }

        public void ChangeState(IState nextState)
        {
            if (currentState != null)
            {
                currentState.OnExit(this);
            }
            currentState = nextState;
            currentState.OnEnter(this);
        }
    }

}