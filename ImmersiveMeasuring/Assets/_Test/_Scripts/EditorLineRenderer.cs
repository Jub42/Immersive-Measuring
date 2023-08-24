using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorLineRenderer : MonoBehaviour
{

    [SerializeField]
    Transform start;
    [SerializeField]
    Transform end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(start.position, end.position, Color.green);
    }
}
