using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGrid : MonoBehaviour
{
    List<GameObject> list = new List<GameObject>();

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int maxRows;
    [SerializeField]
    int maxCols;

    //necessary?
    float cellSizeX = 1;
    float cellSizeY = 1;

    float spacing = 1;

    // Start is called before the first frame update
    void Start()
    {
        int i = list.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddElement()
    {

    }

    void RemoveElement()
    {

    }
}
