using HTC.UnityPlugin.Vive;
using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTDataCube : MonoBehaviour
{
    // Measurement // Get/Set etc.
    // Reference to measurement
    Measurement measurement;

    // visualization -> MGrid? nope!

    // visibility
    // [SerializeField]
    // bool isVisible = true;

    bool isLocked = false;
    // Property

    public bool isPinned = false;

    [SerializeField]
    GameEvent onDestroy;

    // Setup DataCube func
    
    // handle prefab
    [SerializeField]
    List<GameObject> iconList = new List<GameObject>();

    public bool isGrabbed = false;

    [SerializeField]
    float result;

    public bool SetMeasurement(Measurement measurement)
    {
        if (!isLocked)
        {
            this.measurement = measurement;
            isLocked = true;
            this.result = (float)measurement.Result.Value;
            return true;
        }
        else
        {
            return false;
        }     
    }

    public bool GetMeasurement(out Measurement measurement)
    {
        if (!isLocked)
        {
            measurement = this.measurement;
            return true;
        }
        else
        {
            //TODO:
            // Empty Measurement
            // evtl: null
            measurement = new EmptyMeasurement();
            return false;
        }
    }

    private void OnDestroy()
    {
        // GameObjectEvent
        // Queue Task DataStorage
    }

    // Start is called before the first frame update
    void Start()
    {
        // Measurement type ? enum?
        // select item corresponding to measurement type
    }

    // Update is called once per frame
    void Update()
    {
        this.isGrabbed = GetComponent<GrabbableBase>().isGrabbed;
        if(isGrabbed)
        {
            isPinned = false;
        }
    }
}
