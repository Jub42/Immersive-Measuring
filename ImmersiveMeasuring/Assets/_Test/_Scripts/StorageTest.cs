using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageTest : MonoBehaviour
{
    [SerializeField]
    GameObjectStorage storage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(storage.GetValue(1).transform.position);
        

    }
}
