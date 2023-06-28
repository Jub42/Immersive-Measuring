using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Collider>().bounds.Contains(obj.transform.position))
        {
            Debug.Log("##########");
        }

    }
}
