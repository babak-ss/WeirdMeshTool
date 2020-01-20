﻿using UnityEditor;
using UnityEngine;

namespace WeirdMeshTool
{
    [CustomEditor(typeof(TheShape))]
    public class TheShapeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            TheShape theShape = (TheShape)target;

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                theShape.segmentsNum = EditorGUILayout.IntSlider ("Segments Num", theShape.segmentsNum, 0, 10);
                theShape.segmentT = EditorGUILayout.Slider("Segments T", theShape.segmentT, -10, 10);
                theShape.radius = EditorGUILayout.Slider("Radius", theShape.radius, 0, 10);
                
                if (check.changed)
                {
                    Debug.Log("Changed!!");
                    theShape.ChangeTheShape();
                }
            }

            if (GUILayout.Button("Change New Shape"))
            {
                theShape.ChangeTheShape();
            }

        }
        private void OnInspectorUpdate() 
        {
            Debug.Log("OnInspectorUpdate");
            TheShape theShape = (TheShape)target;
            theShape.ChangeTheShape();
        }
    }
}
