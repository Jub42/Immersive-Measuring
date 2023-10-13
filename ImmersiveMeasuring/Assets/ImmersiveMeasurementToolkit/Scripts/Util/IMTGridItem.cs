using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Util
{
    // OnChange Event für Renderer?

    [RequireComponent(typeof(BoxCollider))]
    public class IMTGridItem : MonoBehaviour
    {
        [Header("Grid Item Settings")]
        // Set positionItem always to designated Vector3
        [SerializeField]
        [Tooltip("Designated item positionItem.")]
        Vector3 positionItem;
        [SerializeField]
        Vector3 centerBoxCollider;
        [SerializeField]
        Vector3 sizeBoxCollider;

        [SerializeField]
        bool isOccupied = false;
        public bool IsOccupied
        {
            get { return isOccupied; }
        }

        //necessary?
        [SerializeField]
        GameObject content;

        //Hover
        private void Start()
        {
            SetCollider(centerBoxCollider, sizeBoxCollider);
        }

        void Update()
        {
            RefreshStatus();

            //gameObject.transform.position = positionItem;
        }

        void RefreshStatus()
        {
            if(content != null)
            {
                isOccupied = true;
            }
            if(content == null)
            {
                isOccupied = false;
            }
        }

        public void SetCollider(Vector3 center, Vector3 size)
        {
            BoxCollider collider =  GetComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.center = center;
            collider.size = size;
        }

        public void SetPosition(Vector3 position)
        {
            this.positionItem = position;
        }

        //ontriggerstay controller -> reset positionItem
        void ResetContentPosition()
        {
            if(isOccupied)
            {
                content.transform.position = this.transform.position;
                content.transform.rotation = this.transform.rotation;
            }         
        }
        public void SetContent(GameObject obj)
        {
            if(!isOccupied)
            {
                obj.transform.parent = this.transform;
                content = obj;
                isOccupied = true;
                ResetContentPosition();
            }
            else
            {
                Debug.Log( "GridItem is already occupied!" );
            }
        }
        public GameObject GetContent() { return content; }

        private void OnTriggerStay(Collider other)
        {
            //Outline/ hover
            //Reset content positionItem
            if (other.CompareTag("Player"))
            {
                ResetContentPosition() ;
            }
        }
    }
}