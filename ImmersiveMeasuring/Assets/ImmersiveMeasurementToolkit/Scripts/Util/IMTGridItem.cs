using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Util
{
    [RequireComponent(typeof(IMTGridRenderer))]
    public class IMTGridItem : MonoBehaviour
    {
        [Header("Grid Item Settings")]
        // Set position always to designated Vector3
        Vector3 position;

        [SerializeField]
        bool isOccupied = false;

        //Hover

        [Header("Grid Item Background Settings")]
        [SerializeField]
        bool isVisible = true;
        IMTGridRenderer renderer;
        [SerializeField]
        float height;
        [SerializeField]
        float width;
        [SerializeField]
        Vector3 offset;
        public Material material;

        // Start is called before the first frame update
        void Start()
        {
            renderer = gameObject.GetComponent<IMTGridRenderer>();
            
        }

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.position = position;

            renderer.UpgradeRender(height, width, offset, material);

            if (isVisible)
            {
                renderer.enabled = true;
            }
            else
            {
                renderer.enabled = false;
            }
        }

        public void ShowBackground()
        {
            isVisible = true;
        }
        public void HideBackground()
        {
            isVisible = false;
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