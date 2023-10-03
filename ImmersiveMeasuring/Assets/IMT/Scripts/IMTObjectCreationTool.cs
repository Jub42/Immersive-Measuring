using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IMTObjectCreationTool
{
    public static bool InstantiateMeasurementOnGameObj(Measurement measurement, ref GameObject prefab)
    {
        if (prefab.GetComponent<IMTDataCube>().SetMeasurement(measurement))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // change to ref?
    public static bool ExtractMeasurementData(GameObject dataCube, out Measurement measurement)
    {
        if (dataCube.gameObject.GetComponent<IMTDataCube>() != null)
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

    //public static bool CreateEmptyGameObject(out GameObject obj)

}
