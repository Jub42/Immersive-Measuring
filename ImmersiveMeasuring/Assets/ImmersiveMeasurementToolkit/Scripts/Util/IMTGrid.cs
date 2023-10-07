using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util
{
    public class IMTGrid : MonoBehaviour, IMTObjectPooler
    {
        //height
        // width etc.
        [Header("Grid Settings")]
        [SerializeField]
        int maxRows;
        [SerializeField]
        int maxCols;
        [SerializeField]
        int maxLayers;
        int batchSize;
        [SerializeField]
        [Tooltip("The distance between GridItem centers.")]
        float spacing;

        [SerializeField, Range(0f, 1f)]
        [Tooltip("Select a threshold. If the grid is [warinngThreshold]% filled a warning appears.")]
        float warningThreshold;
        //Warning GameEvent

        // hide/show ?
        [SerializeField]
        [Tooltip("The origin positionItem of the grid (Upper left corner of the grid). Can be set to null.")]
        Transform GridOrigin;
        Vector3 offset;

        [Header("Grid Item")]
        [SerializeField]
        GameObject gridItem;

        [Header("Data")]
        public GameObject[] items;

        // Start is called before the first frame update
        void Start()
        {
            SetupGrid();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void UpdateGrid()
        {
            if (Application.isPlaying)
            {
                ClearData();
                SetupGrid();
            }  
        }

        void ClearData()
        {
            for(int i = 0; i < items.Length; i++)
            {
                Destroy(items[i]);
                items[i] = null;
            }
        }

        public void SetupGrid()
        {
            if (GridOrigin == null)
            {
                offset = transform.position;
            }
            else
            {
                offset = GridOrigin.position;
            }

            batchSize = maxRows * maxCols;
            items = new GameObject[batchSize * maxLayers];

            for (int i = 0; i < items.Length; i++)
            {
                if(gridItem.gameObject.GetComponent<IMTGridItem>() != null)
                {
                    Vector3 v = new Vector3(i % maxCols, -(i / maxCols) % maxRows, -i / batchSize) * spacing;
                    GameObject prefab = Instantiate(gridItem, v, Quaternion.identity, this.transform);
                    prefab.GetComponent<IMTGridItem>().SetPosition(offset + v);
                    items[i] = prefab;
                }
            }
        }

        public bool AddObject(GameObject obj)
        {
            for (int i = 0; i < items.Length; i++)
            {
                IMTGridItem item = items[i].GetComponent<IMTGridItem>();

                if (!item.IsOccupied)
                {
                    item.SetContent(obj);
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
    }
}


