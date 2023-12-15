using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorageTest : MonoBehaviour
{
    [SerializeField]
    GameObjectStorage data;

    [SerializeField]
    GameObject prefab;

    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
         go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown("w"))
        {
            data.AddData(go);
        }
        if (Input.GetKeyDown("s"))
        {
            data.RemoveData(go);
        }

        Debug.Log(data.Count);
    }
}
