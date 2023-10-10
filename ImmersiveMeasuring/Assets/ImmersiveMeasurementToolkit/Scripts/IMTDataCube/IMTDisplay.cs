using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MeasurementUtility;

[RequireComponent(typeof(IMTMeasurementContainer))]
public class IMTDisplay : MonoBehaviour
{
    [SerializeField]
    Transform display;
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    Vector3 relativOffsetPosition;

    // Update is called once per frame
    void Update()
    {
        display.position = this.transform.position + relativOffsetPosition;

        Measurement m = new EmptyMeasurement();

        if (GetComponent<IMTMeasurementContainer>().GetMeasurement(out m))
        {
            text.text = m.ToJson();
        }
        else
        {
            Debug.Log("Couldn't extract m from dataCube");
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
