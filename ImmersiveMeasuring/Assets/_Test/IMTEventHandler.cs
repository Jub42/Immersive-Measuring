using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IMTEventHandler : MonoBehaviour
{

    [SerializeField]
    private UnityEvent<Measurement> OnEventSend;
    [SerializeField]
    private UnityEvent OnEvent;

    public void InvokeEvent(Measurement m)
    {
        OnEventSend?.Invoke(m);
    }

    public void InvokeEvent()
    {
        OnEvent?.Invoke();
    }
}
