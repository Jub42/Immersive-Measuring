using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCube;
using IMTEventSystem;

namespace Util
{
    /// <summary>
    /// Adjusts the State of an IMTDataCube.
    /// </summary>
    [RequireComponent(typeof (BoxCollider))]
    public class IMTAddDataCube : MonoBehaviour
    {
        [SerializeField]
        GameEvent onGridChange;

        private void OnTriggerEnter(Collider other)
        {
            IMTDataCube dc = other.GetComponent<IMTDataCube>();
            if (dc != null)
            {
                dc.SetPinned();

                onGridChange.TriggerEvent();
            }
        }
    }

}
