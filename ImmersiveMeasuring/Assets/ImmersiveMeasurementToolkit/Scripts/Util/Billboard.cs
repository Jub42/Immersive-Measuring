using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// This script aligns an object towards the main camera.
    /// </summary>
    public class Billboard : MonoBehaviour
    {
        void Update()
        {
            transform.LookAt(Camera.main.transform.position);
        }
    }
}


