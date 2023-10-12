using HTC.UnityPlugin.Vive;
using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataCube
{
    public class IMTMeasurementContainer : MonoBehaviour
    {
        Measurement measurement = new EmptyMeasurement();

        bool isLocked = false;
        public bool IsLocked
        {
            get { return isLocked; }
        }

        [SerializeField]
        protected bool isSetUp = false;

        private void LateUpdate()
        {
            if (isLocked && (measurement is not EmptyMeasurement))
            {
                isSetUp = true;
            }
            else
            {
                isSetUp = false;
            }
        }

        public bool SetMeasurement(Measurement measurement)
        {
            Debug.Log("Set Measurement" + measurement.ToJson());
            if (!isLocked)
            {
                this.measurement = measurement;
                isLocked = true;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetMeasurement(out Measurement m)
        {
            m = this.measurement;
            if (isLocked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetRenderData()
        {

        }

    }

}

