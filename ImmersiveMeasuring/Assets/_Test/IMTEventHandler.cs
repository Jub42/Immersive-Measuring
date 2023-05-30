using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IMTEventHandler : MonoBehaviour
{

    [SerializeField]
    private UnityEvent<Measurement> unityEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeEvent(Measurement m)
    {
        unityEvent?.Invoke(m);
    }
}
