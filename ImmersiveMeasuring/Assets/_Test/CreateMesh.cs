using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{
    Mesh mesh;

    void OnEnable()
    {
        mesh = new Mesh
        {
            name = "New Mesh"
        };

        mesh.vertices = new Vector3[] {
            Vector3.zero, Vector3.right, Vector3.up
        };

        mesh.triangles = new int[] {
            0, 2, 1
        };

        mesh.normals = new Vector3[] {
            Vector3.back, Vector3.back, Vector3.back
        };

        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Start is called before the first frame update
    void Start()
    {

        // Get Mesh from hit GameObject
        // filter by normals (just the viewable ones)
        // ray hits mesh?
        GetMeshData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetMeshData()
    {
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
}
