using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCube;
using IMTEventSystem;

namespace Util
{
    /// <summary>
    /// Destroys a DataCube on collision.
    /// </summary>
    [RequireComponent(typeof (BoxCollider))]
    public class IMTRemoveDataCube : MonoBehaviour
    {
        [SerializeField]
        GameEvent onGridChange;

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<IMTDataCube>() != null)
            {
                Destroy(other.gameObject);
                onGridChange.TriggerEvent();
            }
        }
    }

}