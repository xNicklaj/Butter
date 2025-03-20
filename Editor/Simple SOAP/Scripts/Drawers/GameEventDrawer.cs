using UnityEngine;
using UnityEditor;
using System;

namespace Nicklaj.SimpleSOAP
{
    /// <summary>
    /// Custom editor for any ScriptableObject that implements ISerializedRaise interface
    /// </summary>
    [CustomEditor(typeof(ScriptableObject), true)]
    public class SerializedRaiseEditor : Editor
    {
        private string inputArgument = "";
        private bool useDebugLogs = false;
        private ISerializedRaise raiseTarget;
        private bool isRaiseTarget = false;

        private void OnEnable()
        {
            // Check if target implements ISerializedRaise
            raiseTarget = target as ISerializedRaise;
            isRaiseTarget = raiseTarget != null;
        }

        public override void OnInspectorGUI()
        {
            // Draw the default inspector
            DrawDefaultInspector();

            // If not implementing ISerializedRaise, don't add anything
            if (!isRaiseTarget)
                return;

            // Add separator
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            EditorGUILayout.Space();

            // Test event section
            EditorGUILayout.LabelField("Test Event", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Use Debug Logs");
            useDebugLogs = EditorGUILayout.Toggle(useDebugLogs);
            EditorGUILayout.EndHorizontal();

            // Only show input field if the event has an argument
            if (raiseTarget.HasArgument)
            {
                // Get the scriptable type name to give a hint to the user
                string typeName = target.GetType().Name;
                string placeholder = GetPlaceholderFromTypeName(typeName);

                // Draw argument field
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Debug Value");
                inputArgument = EditorGUILayout.TextField(inputArgument, GUILayout.ExpandWidth(true));
                EditorGUILayout.EndHorizontal();

                // Optional: Add hint about expected input type
                EditorGUILayout.HelpBox($"Expected format: {placeholder}", MessageType.Info);
            }

            // Create a button to raise the event
            if (GUILayout.Button("Raise Event"))
            {
                // Call the implementation's OnRaiseButtonSubmit method
                raiseTarget.OnRaiseButtonSubmit(inputArgument);
                if(useDebugLogs) Debug.Log($"Event raised with argument: {(string.IsNullOrEmpty(inputArgument) ? "[none]" : inputArgument)}");
            }
        }

        // Helper method to provide a hint based on the event type name
        private string GetPlaceholderFromTypeName(string typeName)
        {
            if (typeName.Contains("Int")) return "Integer value (e.g. 42)";
            if (typeName.Contains("Float")) return "Float value (e.g. 3.14)";
            if (typeName.Contains("String")) return "Text value";
            if (typeName.Contains("Bool")) return "true or false";
            if (typeName.Contains("Vector2")) return "x,y (e.g. 1,2)";
            if (typeName.Contains("Vector3")) return "x,y,z (e.g. 1,2,3)";

            return "Enter value";
        }
    }

}

