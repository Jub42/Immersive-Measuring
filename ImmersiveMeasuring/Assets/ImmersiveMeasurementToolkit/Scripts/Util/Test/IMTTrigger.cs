using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class IMTTrigger : MonoBehaviour
{
    bool isEntered = false;
    public bool IsEntered
    {
        get { return isEntered; }
    }
    bool isStayed = false;
    public bool IsStayed
    {
        get { return isStayed; }
    }
    bool isExited = false;
    public bool IsExited
    {
        get { return isExited; }
    }
    private void OnTriggerEnter(Collider other)
    {
        isEntered = true;
        isStayed = false;
        isExited = false;
    }
    private void OnTriggerStay(Collider other)
    { 
        isEntered = false;
        isStayed = true;
        isExited = false;
    }
    private void OnTriggerExit(Collider other)
    {
        isEntered = false;
        isStayed = false;
        isExited = true;
    }
}
