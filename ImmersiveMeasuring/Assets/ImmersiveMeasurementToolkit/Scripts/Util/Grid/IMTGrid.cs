using System;
using UnityEngine;
using IMTEventSystem;

namespace Util
{
    /// <summary>
    /// The IMTGrid manages the placement of the selected GridItems.
    /// </summary>
    public class IMTGrid : MonoBehaviour, IMTObjectPooler
    {
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
        [SerializeField]
        GameEvent onWarning;

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
            if(CountOccupied() / items.Length >= warningThreshold)
            {
                onWarning.TriggerEvent();
                Debug.Log("Warning!");
            }
        }
        public void UpdateGrid()
        {
            if (Application.isPlaying)
            {
                ClearData();
                SetupGrid();
            }  
        }

        int CountOccupied()
        {
            int count = 0;

            for(int i = 0; i< items.Length; i++)
            {
                if (items[i].GetComponent<IMTGridItem>().IsOccupied)
                {
                    count++;
                }
            }
            return count;
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
            batchSize = maxRows * maxCols;
            items = new GameObject[batchSize * maxLayers];

            for (int i = 0; i < items.Length; i++)
            {
                if(gridItem.gameObject.GetComponent<IMTGridItem>() != null)
                {
                    Vector3 v = new Vector3(-(i % maxCols), -(i / maxCols) % maxRows, -i / batchSize) * spacing;
                    v = Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z) * v;
                    GameObject prefab = Instantiate(gridItem, this.transform.position + v, this.transform.rotation, this.transform);
                    prefab.name = "GridItem" + i;
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


