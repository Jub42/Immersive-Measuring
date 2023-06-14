using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnEvent;

    public void InvokeEvent()
    {
        OnEvent?.Invoke();
    }
}
