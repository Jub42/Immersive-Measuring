using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTManager : MonoBehaviour
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
        
    }

    // Coroutines?
    public void ImportFromJson()
    {
        // import existing data from json to DataStorage
    }
    public void ExportAsJson(string path)
    {
        // export pinned DataCube information to path as json
    }
}
