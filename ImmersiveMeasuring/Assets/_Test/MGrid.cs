using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof (MeasurementManager))]
public class MGrid : MonoBehaviour
{
    [SerializeField]
    List<GameObject> list;

    [SerializeField]
    GameObject prefab;

    [SerializeField, Range(1, 10)]
    int maxRows = 1;
    [SerializeField, Range(1, 10)]
    int maxCols = 1;
    int maxBatchSize = 1;

    [SerializeField]
    Transform offset; // origin

    [SerializeField]
    float spacing = 1f;

    // Start is called before the first frame update
    void Start()
    {
        int i = list.Count;
    }

    // Update is called once per frame
    void Update()
    {
        // adjust collider
        UpdateVisualization();
    }

    public void UpdateMeasurements()
    {
        Debug.Log("Update Measurements!");
        // Mlist = GetComponent<MeasurementManager>().GetMeasurements();
        // create gameobj list with Mlist
    }

    void UpdateVisualization()
    {
        maxBatchSize = maxRows * maxCols;

        GameObject obj = null;
        bool isGrabbed = false;
        bool isInBounds = false;
        Rigidbody rb;
        Vector3 v = Vector3.zero;
        Vector3 up = Vector3.up;
        Vector3 forward = Vector3.forward;

        for (int i = 0; i < list.Count; i++)
        {
            obj = list[i];

            if (obj == null && i == 0)
            {
                break;
            }

            isGrabbed = obj.GetComponent<VisualMeasurementContainer>().grabbed;
            isInBounds = this.GetComponent<Collider>().bounds.Contains(obj.transform.position);

            if(!isGrabbed && isInBounds)
            {
                rb = obj.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;

                v = new Vector3(i % maxCols, -(i / maxRows) % maxRows, -i / maxBatchSize) * spacing;
                obj.transform.position = offset.position + v;

                // handle in VisualContainer?
                obj.transform.up = up;
                obj.transform.forward = forward;
            }

        }
    }

    void createPrefab(List<Measurement> measurements)
    {
        for(int i = 0; i < measurements.Count; i++)
        {
            // add Prefab to list
            
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
