using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Util
{
    [RequireComponent(typeof(BoxCollider))]
    public class IMTGridItem : MonoBehaviour
    {
        [Header("Grid Item Settings")]
        // Set position always to designated Vector3
        Vector3 position;

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

        void Update()
        {
            RefreshStatus();

            gameObject.transform.position = position;
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
            this.position = position;
        }

        //ontriggerstay controller -> reset position
        void ResetContentPosition()
        {
            if(isOccupied)
            {
                content.transform.localPosition = this.transform.position;
                content.transform.localRotation = this.transform.rotation;
            }         
        }
        public void SetContent(GameObject obj)
        {
            if(!isOccupied)
            {
                obj.transform.parent = this.transform;
                content = obj;
                ResetContentPosition();
            }
            else
            {
                Debug.Log( "GridItem is already occupied!" );
            }
        }
        public GameObject GetContent() { return content; }
        
        // unnecessary
        void DeleteContent()
        {
            if (isOccupied)
            {
                Destroy(content.gameObject);
                content = null;
            }
            else
            {
                Debug.Log("There already is no content!");
            }
            
        }
        private void OnTriggerStay(Collider other)
        {
            //Outline/ hover
            //Reset content position
        }
    }

}