using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event Generic")]
public class GameEventGeneric<T> : ScriptableObject
{
    List<GameEventListenerGeneric<T>> listeners = new List<GameEventListenerGeneric<T>>();

    public void TriggerEvent()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventTriggered();
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
