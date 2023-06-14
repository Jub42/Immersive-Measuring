using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerGeneric<T> : MonoBehaviour
{
    public GameEventGeneric<T> gameEvent;
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
