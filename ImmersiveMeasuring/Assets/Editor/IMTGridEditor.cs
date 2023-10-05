using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Util
{
    [CustomEditor(typeof(IMTGrid))]
    public class IMTGridEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.HelpBox("Updates the Grid only at runtime!", MessageType.Info);

            IMTGrid grid = (IMTGrid)target;
            if (GUILayout.Button("UpdateGrid"))
            {
                grid.UpdateGrid();
            }
        }
    }
}