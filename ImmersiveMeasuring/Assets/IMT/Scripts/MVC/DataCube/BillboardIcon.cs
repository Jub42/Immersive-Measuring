using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardIcon : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
