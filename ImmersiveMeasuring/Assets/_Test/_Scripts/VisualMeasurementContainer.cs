using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeasurementUtility;

public class VisualMeasurementContainer : MonoBehaviour
{
    Measurement measurement;

    bool toggleVisualization = true;

    [SerializeField]
    GameObject indicator;

    [SerializeField]
    GameObject visual;

    [SerializeField]
    public bool grabbed;

    public void SetMeasurement(Measurement measurement)
    {
        this.measurement = measurement;
    }

    public void ToggleVisualization()
    {
        toggleVisualization = !toggleVisualization;
    }

    public void UpdateVisualization()
    {
        // switch case: measurement type -> Vis
    }

    public void UpdateIcon()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleVisualization)
        {
            // indicator set state
            // show vis
        }
    }
}
