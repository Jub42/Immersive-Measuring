using MeasurementUtility;
using UnityEngine;
using Measurements;

namespace Util
{
    /// <summary>
    /// This class provides methods for the handling of Measurements in DataCubes.
    /// </summary>
    public static class IMTObjectCreationTool
    {
        public static bool InstantiateMeasurementOnGameObj(Measurement measurement, ref GameObject prefab)
        {
            if (prefab.GetComponent<IMTMeasurementContainer>().SetMeasurement(measurement))
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
            if (dataCube.gameObject.GetComponent<IMTMeasurementContainer>() != null)
            {
                dataCube.gameObject.GetComponent<IMTMeasurementContainer>().GetMeasurement(out measurement);
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
}


