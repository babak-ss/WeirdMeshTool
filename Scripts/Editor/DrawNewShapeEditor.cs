﻿using UnityEditor;
using UnityEngine;

namespace WeirdMeshTool
{
    [CustomEditor(typeof(DrawNewShape))]
    public class DrawNewShapeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawNewShape drawShape = (DrawNewShape)target;

            drawShape.segmentsNum = EditorGUILayout.IntField(new GUIContent("Segments Num"), drawShape.segmentsNum);
            drawShape.segmentT = EditorGUILayout.FloatField(new GUIContent("Segments T"), drawShape.segmentT);
            drawShape.radius = EditorGUILayout.FloatField(new GUIContent("Radius"), drawShape.radius);

            if(GUILayout.Button("Draw New Shape"))
            {
                drawShape.Draw();
            }
        }
    }
}
