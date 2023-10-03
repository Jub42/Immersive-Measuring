using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class IMTGridRenderer : MonoBehaviour
    {
        Mesh mesh;
        MeshRenderer renderer;
        MeshFilter filter;

        float height = 0f;
        float width = 0f;
        Vector3 offset = Vector3.zero;

        Material material;

        bool isSetUp = false;

        // Start is called before the first frame update
        void Start()
        {
            filter = gameObject.AddComponent<MeshFilter>();
            renderer = gameObject.AddComponent<MeshRenderer>();
            mesh = GetComponent<MeshFilter>().mesh;

            mesh.Clear();
        }

        // Update is called once per frame
        void Update()
        {
            // iterate griditems and render background

            if (isSetUp)
            {
                // Two Triangles
                Vector3 upperLeft = transform.position + offset + (Vector3.left * width / 2f) + (Vector3.up * height / 2f);
                Vector3 upperRight = transform.position + offset + (Vector3.right * width / 2f) + (Vector3.up * height / 2f);
                Vector3 lowerLeft = transform.position + offset + (Vector3.left * width / 2f) + (Vector3.down * height / 2f);
                Vector3 lowerRight = transform.position + offset + (Vector3.right * width / 2f) + (Vector3.down * height / 2f);

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

        public void UpgradeRender(float height, float width, Vector3 offset, Material material)
        {
            this.height = height;
            this.width = width;
            this.offset = offset;
            this.material = material;
            isSetUp = true;
        }
    }
}
