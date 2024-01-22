using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMTEventSystem
{
    /// <summary>
    /// Similar to GameEventGeneric. Not in use!
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Game Event <Object>")]
    public class ObjectGameEvent : ScriptableObject
    {
        List<ObjectGameEventListener> listeners = new List<ObjectGameEventListener>();

        public void TriggerEvent(Object obj)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].OnEventTriggered(obj);
            }
        }

        public void AddListener(ObjectGameEventListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(ObjectGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}

