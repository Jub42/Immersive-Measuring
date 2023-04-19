using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField]
    Transform start;

    [SerializeField]
    Transform end;

    Vector3[] positions= new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        positions[0] = start.position;
        positions[1] = end.position;     
    }

    private void FixedUpdate()
    {
        lineRenderer.SetPositions(positions);
    }
}
