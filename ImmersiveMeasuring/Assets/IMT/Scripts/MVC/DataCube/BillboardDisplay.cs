using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DataCube;

public class BillboardDisplay : MonoBehaviour
{
    [SerializeField]
    Transform display;

    [SerializeField]
    IMTDataCube dataCube;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    float displayOffsetLength;
    Vector3 displayPosition;

    void Awake()
    {
        display.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
    void SetupDisplay()
    {
        Measurement measurement = new EmptyMeasurement();

        if (dataCube.GetMeasurement(out measurement))
        {
            text.text = measurement.ToJson();
        }
        else
        {
            Debug.Log("Couldn't extract measurement from dataCube");
        }

    }

    void Update()
    {
        displayPosition = dataCube.transform.position + (Camera.main.transform.position - dataCube.transform.position).normalized * displayOffsetLength;
        this.transform.position = displayPosition;
        
        Debug.DrawLine(dataCube.transform.position, displayPosition, Color.green);

        if (this.gameObject.activeSelf)
        {
            transform.LookAt(Camera.main.transform.position);
        } 

        if(dataCube.IsLocked)
        {
            SetupDisplay();
        }

    }

    public void OnHoverEnter()
    {
        display.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
    }
    public void OnHoverExit()
    {
        display.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}
