using HTC.UnityPlugin.Vive;
using MeasurementUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IMTDataCube : MonoBehaviour
{
    // Measurement // Get/Set etc.
    // Reference to m
    Measurement measurement = new EmptyMeasurement();

    // visualization -> MGrid? nope!

    // visibility
    // [SerializeField]
    // bool isVisible = true;
    bool isLocked = false;
    // Property
    public bool IsLocked
    {
        get { return isLocked; }
    }

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
        Debug.Log("Set Measurement" + measurement.ToJson());
        if (!isLocked)
        {
            this.measurement = measurement;
            isLocked = true;
            this.result = (float)measurement.Result.Value;

            Debug.Log("Hier! " + measurement.ToJson());

            return true;
        }
        else
        {
            return false;
        }     
    }

    public bool GetMeasurement(out Measurement m)
    {
        m = this.measurement;
        if (isLocked)
        { 
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDestroy()
    {
        // GameObjectEvent
        // Queue Task DataStorage
    }

    // Update is called once per frame
    void Update()
    {
        SelectIcon(measurement);
        this.isGrabbed = GetComponent<GrabbableBase>().isGrabbed;
        if(isGrabbed)
        {
            isPinned = false;
        }
    }

    // TODO: Maybe other solution: No fixed positions
    void SelectIcon(Measurement m)
    {
        for (int i = 0; i < iconList.Count; i++)
        {
            // Debug.Log(i + " active: " + iconList[i].gameObject.activeSelf);
            iconList[i].gameObject.SetActive(false);
        }
        
        switch (m)
        {
            case Distance:
                iconList[3].gameObject.SetActive(true);
                Debug.Log("Distance Icon Selected.");
                break;
            case EmptyMeasurement:
                iconList[0].gameObject.SetActive(true);
                Debug.Log("Empty Icon Selected.");
                break;
            default:
                Debug.Log("No Icon selected!");
                break;
        }
    }
}
