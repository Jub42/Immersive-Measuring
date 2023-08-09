using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BillboardDisplay : MonoBehaviour
{
    [SerializeField]
    Transform display;

    [SerializeField]
    IMTDataCube dataCube;

    [SerializeField]
    TMP_Text text;

    void Awake()
    {
        display.gameObject.SetActive(false);

        Measurement measurement = new EmptyMeasurement();

        if(dataCube.GetMeasurement(out measurement))
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
        if (this.gameObject.activeSelf)
        {
            transform.LookAt(Camera.main.transform.position);
        } 
    }

    public void OnHoverEnter()
    {
        display.gameObject.SetActive(true); 
    }
    public void OnHoverExit()
    {
        display.gameObject.SetActive(false);
    }
}
