using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class IMTTrigger : MonoBehaviour
{
    public bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        isTriggered= true;
    }
    private void OnTriggerExit(Collider other)
    {
        isTriggered= false;
    }
}
