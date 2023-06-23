using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListenerGeneric<T> : MonoBehaviour
{
    public GameEventGeneric<T> gameEvent;
    public UnityEvent<T> onEventTriggered;

    void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnEventTriggered(T t)
    {
        onEventTriggered?.Invoke(t);
    }
}