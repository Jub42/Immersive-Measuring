using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCube;
using IMTEventSystem;

namespace Util
{
    [RequireComponent(typeof (BoxCollider))]
    public class IMTAddDataCube : MonoBehaviour
    {
        [SerializeField]
        GameEvent onGridChange;

        private void OnTriggerEnter(Collider other)
        {
            DataCube.IMTDataCube dc = other.GetComponent<DataCube.IMTDataCube>();
            if (dc != null)
            {
                dc.SetPinned();

                onGridChange.TriggerEvent();
            }
        }
    }

}
