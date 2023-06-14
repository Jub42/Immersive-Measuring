using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHandlerGeneric : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Measurement> OnEventSendMeasurement;

    public void InvokeEvent(Measurement m)
    {
        OnEventSendMeasurement?.Invoke(m);
    }
}
