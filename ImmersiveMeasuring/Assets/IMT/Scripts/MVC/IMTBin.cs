using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTBin : MonoBehaviour
{
    [SerializeField]
    MeasurementGameEvent OnDelete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.GetComponent<IMTDataCube>().isGrabbed && !other.GetComponent<IMTDataCube>().isPinned)
        {
            Destroy(other.gameObject);
        }
    }
}
