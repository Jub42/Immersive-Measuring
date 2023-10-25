using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCube;

namespace Util
{
    [RequireComponent(typeof (BoxCollider))]
    public class IMTRemoveDataCube : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<IMTDataCube>() != null)
            {
                Destroy(other.gameObject);
            }
        }
    }

}