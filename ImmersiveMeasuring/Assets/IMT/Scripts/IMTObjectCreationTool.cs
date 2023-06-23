using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IMTObjectCreationTool
{
    public static bool InstantiateMeasurementGameObj(Measurement measurement, out GameObject prefab)
    {
        prefab = Object.Instantiate(Resources.Load("_Test/Prefabs/DataCube")) as GameObject;
        if (prefab.GetComponent<IMTDataCube>().SetMeasurement(ref measurement))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ExtractMeasurementData(GameObject dataCube, out Measurement measurement)
    {
        if(dataCube.gameObject.GetComponent<IMTDataCube>() != null)
        {
            dataCube.gameObject.GetComponent<IMTDataCube>().GetMeasurement(out measurement);
            return true;
        }
        else
        {
            measurement = new EmptyMeasurement();
            return false;
        }
    }
}
