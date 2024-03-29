using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// This class adds a button to the Inspector UI, in order to update the grid.
    /// </summary>
    [CustomEditor(typeof(IMTGrid))]
    public class IMTGridEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("The first element of the grid is positioned at grids transform.position", MessageType.Info);

            DrawDefaultInspector();

            EditorGUILayout.HelpBox("Updates the grid only at runtime!", MessageType.Info);

            IMTGrid grid = (IMTGrid)target;
            if (GUILayout.Button("UpdateGrid"))
            {
                grid.UpdateGrid();
            }
        }
    }
}