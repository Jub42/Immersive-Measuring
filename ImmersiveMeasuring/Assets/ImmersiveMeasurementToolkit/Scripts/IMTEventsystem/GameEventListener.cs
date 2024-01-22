using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IMTEventSystem
{
    /// <summary>
    /// GameEventListener for the GameEvent.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        // The GameEvent to listen for.
        public GameEvent gameEvent;
        // An UnityEvent in order to select a function as reaction in the inspector.
        public UnityEvent onEventTriggered;

        void OnEnable()
        {
            gameEvent.AddListener(this);
        }
        void OnDisable()
        {
            gameEvent.RemoveListener(this);
        }
        public void OnEventTriggered()
        {
            onEventTriggered?.Invoke();
        }
    }
}


