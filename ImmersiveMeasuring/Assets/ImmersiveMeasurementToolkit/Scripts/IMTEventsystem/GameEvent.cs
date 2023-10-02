using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMTEventSystem
{
    [CreateAssetMenu(menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        List<GameEventListener> listeners = new List<GameEventListener>();

        public void TriggerEvent()
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].OnEventTriggered();
            }
        }

        public void AddListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}


