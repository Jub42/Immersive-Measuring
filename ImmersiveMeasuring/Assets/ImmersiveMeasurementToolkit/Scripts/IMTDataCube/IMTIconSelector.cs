using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Measurements;

namespace DataCube
{
    [RequireComponent(typeof(IMTMeasurementContainer))]
    public class IMTIconSelector : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> iconList = new List<GameObject>();

        bool isSelected = false;

        void Start()
        {
            if (GetComponent<IMTMeasurementContainer>().IsLocked && isSelected == false)
            {
                Measurement m = new EmptyMeasurement();
                if (GetComponent<IMTMeasurementContainer>().GetMeasurement(out m))
                {
                    SelectIcon(m);
                    isSelected = true;
                }
            }
        }

        void SelectIcon(Measurement m)
        {
            for (int i = 0; i < iconList.Count; i++)
            {
                // Debug.Log(i + " active: " + iconList[i].gameObject.activeSelf);
                iconList[i].gameObject.SetActive(false);
            }

            switch (m)
            {
                case Distance:
                    iconList[3].gameObject.SetActive(true);
                    Debug.Log("Distance Icon Selected.");
                    break;
                case EmptyMeasurement:
                    iconList[0].gameObject.SetActive(true);
                    Debug.Log("Empty Icon Selected.");
                    break;
                default:
                    Debug.Log("No Icon selected!");
                    break;
            }
        }
    }

}

