using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RotateToFace))]
public class RotateToFaceEditor : Editor
{
    override public void OnInspectorGUI()
    {
        serializedObject.Update();

        var rotateToFace = target as RotateToFace;

        serializedObject.FindProperty("sprites").objectReferenceValue = EditorGUILayout.ObjectField("Sprites", rotateToFace.sprites, typeof(Transform), true) as Transform;
        serializedObject.FindProperty("rotSpeed").floatValue = EditorGUILayout.FloatField("Rotation Speed", rotateToFace.rotSpeed);
        serializedObject.FindProperty("faceCursor").boolValue = GUILayout.Toggle(rotateToFace.faceCursor, "Face Cursor");

        if (!serializedObject.FindProperty("faceCursor").boolValue)
        {
            serializedObject.FindProperty("targetToFace").objectReferenceValue = EditorGUILayout.ObjectField("Target", rotateToFace.targetToFace, typeof(Transform), true) as Transform;
        }

        serializedObject.FindProperty("targetPos").vector3Value = EditorGUILayout.Vector3Field("Target Pos", rotateToFace.targetPos);

        serializedObject.ApplyModifiedProperties();
    }
}
