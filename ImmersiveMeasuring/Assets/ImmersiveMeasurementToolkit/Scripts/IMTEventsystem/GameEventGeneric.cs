using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMTEventSystem
{
    /// <summary>
    /// Same as GameEvent.cs just with a generic parameter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GameEventGeneric<T> : ScriptableObject
    {
        List<GameEventListenerGeneric<T>> listeners = new List<GameEventListenerGeneric<T>>();

        public void TriggerEvent(T t)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].OnEventTriggered(t);
            }
        }

        public void AddListener(GameEventListenerGeneric<T> listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(GameEventListenerGeneric<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}