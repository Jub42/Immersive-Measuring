using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class IMTLineRenderer : MonoBehaviour
{
    [SerializeField]
    Transform originMarker;
    [SerializeField]
    Transform targetMarker;

    LineRenderer lineRenderer;
    [SerializeField]
    float lineWidth = .025f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(originMarker != null && targetMarker != null)
        {
            lineRenderer.widthMultiplier = lineWidth;
            lineRenderer.SetPosition(0, originMarker.position);
            lineRenderer.SetPosition(1, targetMarker.position);
        }
        else
        {
            Debug.Log("Missing Reference!");
        }

        
    }
}
