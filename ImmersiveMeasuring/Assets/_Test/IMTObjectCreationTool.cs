using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IMTObjectCreationTool
{
    public static bool InstantiateMeasurementGameObj(Measurement measurement, out GameObject prefab)
    {
        prefab = Object.Instantiate(Resources.Load("_Test/Prefabs/DataCube")) as GameObject;
        if (prefab.GetComponent<IMTDataCube>().SetMeasurement(measurement))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
