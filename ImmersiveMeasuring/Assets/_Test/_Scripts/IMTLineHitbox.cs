using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CapsuleCollider))]
public class IMTLineHitbox : MonoBehaviour
{
    CapsuleCollider collider;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCollider(float radius, float length, Vector3 start, Vector3 end)
    {
        collider = GetComponent<CapsuleCollider>();
        collider.radius = radius;
        collider.height = length * Vector3.Distance(start, end);
        collider.direction = 2; // z direction
        Vector3 newPosition = (end - start) * .5f;
        collider.center = Vector3.zero;
    }
}
