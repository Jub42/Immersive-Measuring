using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GetMeshData : MonoBehaviour
{
    Mesh mesh;
    Vector3[] verts;

    private void OnEnable()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        verts = mesh.vertices;
        using (var dataArray = Mesh.AcquireReadOnlyMeshData(mesh))
        {
            var data = dataArray[0];
            // prints "2"
            Debug.Log(data.vertexCount);
            var gotVertices = new NativeArray<Vector3>(mesh.vertexCount, Allocator.TempJob);
            data.GetVertices(gotVertices);
            // prints "(1.0, 1.0, 1.0)" and "(0.0, 0.0, 0.0)"
            foreach (var v in gotVertices)
                Debug.Log(v);
            gotVertices.Dispose();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
