using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTDataCube : MonoBehaviour
{
    // Measurement // Get/Set etc.
    // Reference to measurement
    Measurement measurement;

    // visualization -> MGrid

    // visibility
    // [SerializeField]
    // bool isVisible = true;

    bool isLocked = false;

    // Setup DataCube func
    
    // handle prefab
    [SerializeField]
    List<GameObject> iconList = new List<GameObject>();

    public bool SetMeasurement(ref Measurement measurement)
    {
        if (!isLocked)
        {
            this.measurement = measurement;
            isLocked= true;
            return true;
        }
        else
        {
            return false;
        }     
    }

    public bool GetMeasurementID(out Measurement measurement)
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
    public Measurement GetMeasurement()
    {
        return measurement;
    }


    //TODO: Destroy // see: Manager

    // Start is called before the first frame update
    void Start()
    {
        // Measurement type ? enum?
        // select item corresponding to measurement type
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
