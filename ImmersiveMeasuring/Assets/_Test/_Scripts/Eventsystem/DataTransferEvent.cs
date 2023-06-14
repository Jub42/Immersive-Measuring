using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DataTransferEvent<T> : EventWrapper
{
    UnityEvent<T> unityEvent;
    T type;

    public DataTransferEvent(T t)
    {
        type = t;
    }

    public void Invoke()
    {
        unityEvent.Invoke(type);
    }
}
