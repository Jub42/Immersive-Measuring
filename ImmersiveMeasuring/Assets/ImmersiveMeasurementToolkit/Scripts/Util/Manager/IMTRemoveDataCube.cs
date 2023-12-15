using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCube;
using IMTEventSystem;

namespace Util
{
    [RequireComponent(typeof (BoxCollider))]
    public class IMTRemoveDataCube : MonoBehaviour
    {
        [SerializeField]
        GameEvent onGridChange;

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<DataCube.IMTDataCube>() != null)
            {
                Destroy(other.gameObject);
                onGridChange.TriggerEvent();
            }
        }
    }

}