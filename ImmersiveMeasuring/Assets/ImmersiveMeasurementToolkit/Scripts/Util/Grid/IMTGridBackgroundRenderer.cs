using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// Renders a Square in order to indicate the position and size of a GridItem.
    /// </summary>
    public class IMTGridBackgroundRenderer : MonoBehaviour
    {
        Mesh mesh;
        MeshRenderer renderer;
        MeshFilter filter;

        [SerializeField]
        float height;
        [SerializeField]
        float width;
        [SerializeField]
        Vector3 offset;
        [SerializeField]
        Material material;

        private void Start()
        {
            Render();
        }

        public void Render()
        {
            filter = gameObject.AddComponent<MeshFilter>();
            renderer = gameObject.AddComponent<MeshRenderer>();
            mesh = GetComponent<MeshFilter>().mesh;
            mesh.MarkDynamic();

            mesh.Clear();

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
            // Two Triangles
            mesh.triangles = new int[] { 0, 3, 1, 0, 2, 3 };
            renderer.material = material;
        }
    }
}
