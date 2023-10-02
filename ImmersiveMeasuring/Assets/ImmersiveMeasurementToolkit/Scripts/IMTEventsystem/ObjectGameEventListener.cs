using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IMTEventSystem
{
    public class ObjectGameEventListener : MonoBehaviour
    {
        public ObjectGameEvent gameEvent;
        public UnityEvent<Object> onEventTriggered;

        void OnEnable()
        {
            gameEvent.AddListener(this);
        }
        void OnDisable()
        {
            gameEvent.RemoveListener(this);
        }
        public void OnEventTriggered(Object obj)
        {
            onEventTriggered?.Invoke(obj);
        }
    }
}


