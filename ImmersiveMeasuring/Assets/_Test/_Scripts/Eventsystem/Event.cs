using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event : EventWrapper
{
    UnityEvent unityEvent;

    public Event()
    {
    }

    public void Invoke()
    {
        unityEvent.Invoke();
    }
}
