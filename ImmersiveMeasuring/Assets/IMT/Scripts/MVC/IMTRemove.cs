using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class IMTRemove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<IMTDataCube>().isGrabbed && !other.GetComponent<IMTDataCube>().isPinned)
        {
            Destroy(other.gameObject);
        }
    }
}
