using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util
{
    public class IMTGrid : MonoBehaviour
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
        [Tooltip("The origin position of the grid (Upper left corner of the grid). Can be set to null.")]
        Transform GridOrigin;
        Vector3 offset;

        public GameObject[] data;

        [Header("Grid Item Renderer Settings")]
        [SerializeField]
        bool showBackground = false;
        [SerializeField]
        float height;
        [SerializeField]
        float width;
        [SerializeField]
        Vector3 backgroundOffset;
        [SerializeField]
        Material material;

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
            for(int i = 0; i < data.Length; i++)
            {
                Destroy(data[i]);
                data[i] = null;
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
            data = new GameObject[batchSize * maxLayers];

            for (int i = 0; i < data.Length; i++)
            {
                GameObject go = new GameObject("IMTGridItem" + i);

                IMTGridItem item = go.AddComponent<IMTGridItem>();
                Vector3 v = new Vector3(i % maxCols, -(i / maxCols) % maxRows, -i / batchSize) * spacing;
                item.SetPosition(offset + v);

                IMTGridRenderer renderer = go.AddComponent<IMTGridRenderer>();
                renderer.Render(height, width, backgroundOffset, material);
                if(showBackground)
                {
                    renderer.gameObject.SetActive(true);
                }
                else
                {
                    renderer.gameObject.SetActive(false);
                }

                go.transform.parent = this.transform;

                data[i] = go;
            }
        }

        public IMTGridItem GetEmptyItem()
        {
            return null;
        }
    }
}


