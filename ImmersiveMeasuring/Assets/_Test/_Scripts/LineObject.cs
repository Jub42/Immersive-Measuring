using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObject : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField]
    Transform lineStart;
    [SerializeField]
    Transform lineEnd;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lineStart == null || lineEnd == null) return;

        lineRenderer.SetPosition(0,lineStart.position);
        lineRenderer.SetPosition(1,lineEnd.position);
    }
}
