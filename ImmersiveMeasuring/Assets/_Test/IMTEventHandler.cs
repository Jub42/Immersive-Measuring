using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IMTEventHandler : MonoBehaviour
{

    [SerializeField]
    private UnityEvent<Measurement> OnEventSendMeasurement;
    [SerializeField]
    private UnityEvent OnEvent;

    public void InvokeEvent(Measurement m)
    {
        OnEventSendMeasurement?.Invoke(m);
    }

    public void InvokeEvent()
    {
        OnEvent?.Invoke();
    }
}
