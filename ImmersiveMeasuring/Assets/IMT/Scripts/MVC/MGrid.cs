using MeasurementUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using IMTEventSystem;

// get objects and places it
[RequireComponent(typeof(BoxCollider))]
public class MGrid : MonoBehaviour
{
    [SerializeField]
    GameEvent onGridChangeEvent;
    
    [SerializeField]
    public List<GameObject> data = new List<GameObject>();

    int lastDataCount = 0;

    [SerializeField, Range(1, 10)]
    int maxRows = 1;
    [SerializeField, Range(1, 10)]
    int maxCols = 1;
    int maxBatchSize = 1;

    [SerializeField]
    Transform offset; // originMarker

    [SerializeField]
    float spacing = 1f;

    // Add Gizmo?
    [SerializeField, Range(-360, 360)]
    float xRotation = 0f;
    [SerializeField, Range(-360, 360)]
    float yRotation = -90f;
    [SerializeField, Range(-360, 360)]
    float zRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // adjust collider
        
    }

    void FixedUpdate()
    {
        UpdateGrid();
        
    }

    public void UpdateMeasurements()
    {
        Debug.Log("Update Measurements!");
        // Mlist = GetComponent<MeasurementManager>().GetMeasurements();
        // create gameobj items with Mlist
    }

    void UpdateGrid()
    {
        //TODO: Set DataCube kinetic 

        maxBatchSize = maxRows * maxCols;

        GameObject obj = null;
        bool isGrabbed = false;
        bool isInBounds = false;
        bool isPinned = false;
        Rigidbody rb;
        Vector3 v = Vector3.zero;
        Vector3 up = Vector3.up;
        Vector3 forward = Vector3.forward;

        for (int i = 0; i < data.Count; i++)
        {
            obj = data[i];

            if (obj == null && i == 0)
            {
                break;
            }

            isGrabbed = obj.GetComponent<IMTDataCube>().isGrabbed;
            isInBounds = this.GetComponent<Collider>().bounds.Contains(obj.transform.position);
            isPinned = obj.GetComponent<IMTDataCube>().isPinned;

            //Debug.Log("grabbed: " + isGrabbed + "bounds: " + isInBounds + "pinned: " + isPinned + "");

            // DataCube is added to items without set it's positionItem.
            // This way the items.Count changes and the preexisting DataCubes are placed, while the
            // first positionItem is not occupied by a DataCube.
            if (!isGrabbed && isInBounds && isPinned)
            {
                rb = obj.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;              

                v = new Vector3(i % maxCols, -(i / maxCols) % maxRows, -i / maxBatchSize) * spacing;
                
                // rotate around world axis
                v = Quaternion.Euler(xRotation, yRotation, zRotation) * v;
                obj.transform.position = offset.position + v;
                
                // handle in VisualContainer?
                obj.transform.up = up;
                obj.transform.forward = forward;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IMTDataCube>() != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
            data.Add(other.gameObject);
            onGridChangeEvent.TriggerEvent();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IMTDataCube>() != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            //see datacube: other.GetComponent<IMTDataCube>().isPinned= false;
            data.Remove(other.gameObject);
            onGridChangeEvent.TriggerEvent();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Manager method
        // add obj
    }

    private void OnCollisionExit(Collision collision)
    {
        // Manager method
        // remove obj
    }

}
