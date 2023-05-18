using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MGrid : MonoBehaviour
{
    [SerializeField]
    List<GameObject> list;

    [SerializeField]
    GameObject prefab;

    [SerializeField, Min(1)]
    int maxRows = 1;
    [SerializeField, Min(1)]
    int maxCols = 1;
    [SerializeField, Min(1)]
    int maxBatchSize = 1;

    [SerializeField]
    Transform offset; // origin

    [SerializeField]
    float spacing = 1f;

    // Start is called before the first frame update
    void Start()
    {
        int i = list.Count;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVisualization();
    }

    void UpdateVisualization()
    {
        maxBatchSize = maxRows * maxCols;

        for(int i = 0; i < list.Count; i++)
        {
            Vector3 v = new Vector3(i % maxCols, - (i / maxRows) % maxRows, - i / maxBatchSize) * spacing;
            list[i].transform.position = offset.position + v;
        }
    }

    void createPrefab()
    {

    }
}
