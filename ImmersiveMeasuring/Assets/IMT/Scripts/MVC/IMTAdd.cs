using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTAdd : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<IMTDataCube>().isPinned = true;
    }
}
