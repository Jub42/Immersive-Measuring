using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class IMTGridBackgroundRenderer : MonoBehaviour
    {
        Mesh mesh;
        MeshRenderer renderer;
        MeshFilter filter;

        [SerializeField]
        bool isSetUp = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // iterate griditems and render background

            
        }

        public void Setup()
        {
            filter = gameObject.AddComponent<MeshFilter>();
            renderer = gameObject.AddComponent<MeshRenderer>();
            mesh = GetComponent<MeshFilter>().mesh;
            mesh.MarkDynamic();

            mesh.Clear();
        }

        public void Render(float height, float width, Vector3 offset, Material material)
        {  
            Setup();

            // Two Triangles
            Vector3 upperLeft = offset + (Vector3.left * width / 2f) + (Vector3.up * height / 2f);
            Vector3 upperRight = offset + (Vector3.right * width / 2f) + (Vector3.up * height / 2f);
            Vector3 lowerLeft = offset + (Vector3.left * width / 2f) + (Vector3.down * height / 2f);
            Vector3 lowerRight = offset + (Vector3.right * width / 2f) + (Vector3.down * height / 2f);

            mesh.vertices = new Vector3[] { upperLeft, upperRight, lowerLeft, lowerRight };

            Vector2[] uvs = new Vector2[mesh.vertices.Length];

            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = new Vector2(mesh.vertices[i].x, mesh.vertices[i].z);
            }
            mesh.uv = uvs;
            mesh.triangles = new int[] { 0, 3, 1, 0, 2, 3 };
            renderer.material = material;
        }
    }
}
