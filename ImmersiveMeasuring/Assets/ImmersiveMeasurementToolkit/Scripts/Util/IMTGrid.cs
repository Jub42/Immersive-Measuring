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

        [SerializeField]
        int maxRows;
        [SerializeField]
        int maxCols;
        [SerializeField]
        int maxLayers;
        int batchSize;
        [SerializeField]
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

        [SerializeField]
        Material material;

        // Start is called before the first frame update
        void Start()
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

            SetupGrid();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetupGrid()
        {
            for (int i = 0; i < data.Length; i++)
            {
                GameObject go = new GameObject("IMTGridItem" + i);
                IMTGridItem item = go.AddComponent<IMTGridItem>();
                go.transform.parent = this.transform;
                Vector3 v = new Vector3(i % maxCols, -(i / maxCols) % maxRows, -i / batchSize) * spacing;

                item.SetPosition(offset + v);
                item.material = this.material;
                

                data[i] = go;
            }
        }

        public IMTGridItem GetEmptyItem()
        {
            return null;
        }
    }
}

