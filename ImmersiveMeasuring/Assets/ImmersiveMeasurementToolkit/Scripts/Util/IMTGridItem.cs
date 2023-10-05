using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Util
{
    public class IMTGridItem : MonoBehaviour
    {
        [Header("Grid Item Settings")]
        // Set position always to designated Vector3
        Vector3 position;

        [SerializeField]
        bool isOccupied = false;

        //Hover

        void Update()
        {
            gameObject.transform.position = position;
        }

        public void SetPosition(Vector3 position)
        {
            this.position = position;
        }

        void ResetContentPosition()
        {
            //getchild + reset to position
        }
        void SetContent()
        {
            isOccupied = true;
        }
        void DeleteContent()
        {
            isOccupied = false;
        }
    }

}