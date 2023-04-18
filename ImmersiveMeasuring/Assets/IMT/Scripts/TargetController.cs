using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    RaycastHit hit;
    [SerializeField]
    float distance = 1000f;
    Vector3 offset = new Vector3(0f, .5f, 0f);
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, distance, layerMask))
            {
                transform.position = hit.point + offset;
            }
        }
    }
}
