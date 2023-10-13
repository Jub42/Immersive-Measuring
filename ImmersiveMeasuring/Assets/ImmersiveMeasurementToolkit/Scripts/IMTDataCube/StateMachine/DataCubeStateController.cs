using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class DataCubeStateController : MonoBehaviour
    {
        protected IState currentState;
        public IState CurrentState { get { return currentState; } }

        public StartState startState = new StartState();

        // Start is called before the first frame update
        protected virtual void Start()
        {
            ChangeState(startState);
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