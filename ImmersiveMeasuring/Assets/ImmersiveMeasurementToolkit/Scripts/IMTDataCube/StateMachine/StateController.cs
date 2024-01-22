using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    /// <summary>
    /// Generic StateController.
    /// </summary>
    public class StateController : MonoBehaviour
    {
        protected IState currentState;
        public IState CurrentState { get { return currentState; } }

        public StartState startState = new StartState();

        protected virtual void Start()
        {
            ChangeState(startState);
        }

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