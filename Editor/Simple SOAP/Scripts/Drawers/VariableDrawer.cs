using System;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    public abstract class VariableDrawer<T> : PropertyDrawer
    {
        // Dictionary to track variables we're displaying and their current value text
        private static readonly System.Collections.Generic.Dictionary<int, string> valueDisplayCache = 
            new System.Collections.Generic.Dictionary<int, string>();  
         
        // Keep track of which variables we've already subscribed to for change events
        private static readonly System.Collections.Generic.HashSet<int> subscribedVariables =
            new System.Collections.Generic.HashSet<int>();
            
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ScriptableVariable<T> variable = property.objectReferenceValue as ScriptableVariable<T>;
            bool IsNull = variable == null;
            // Height for the object field plus the value display (with padding)
            return IsNull ? EditorGUIUtility.singleLineHeight : EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            // Get the current value of the property
            ScriptableVariable<T> variable = property.objectReferenceValue as ScriptableVariable<T>;
            bool IsNull = variable == null;
            
            // Split the rect into two rows
            Rect objectFieldRect = new Rect(
                position.x, 
                position.y, 
                position.width, 
                IsNull ? position.height : EditorGUIUtility.singleLineHeight
            );
            
            // The object field for the scriptable variable
            EditorGUI.ObjectField(
                objectFieldRect, 
                property, 
                typeof(ScriptableVariable<T>), 
                label
            );

            
            // Handle the value display
            if (!IsNull)
            {
                int variableId = variable.GetInstanceID();
                
                Rect valueLabelRect = new Rect(
                    position.x + 20, // Indent the value display
                    position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing, 
                    position.width - 20, 
                    EditorGUIUtility.singleLineHeight
                );
                
                // Subscribe to value changes if we haven't already
                if (!subscribedVariables.Contains(variableId))
                {
                    variable.OnValueChanged += _ => {
                        // Update the cached display value and force a repaint
                        valueDisplayCache[variableId] = DisplayString(variable);
                        EditorUtility.SetDirty(property.serializedObject.targetObject);
                    };
                    subscribedVariables.Add(variableId);
                    
                    // Initialize the display value
                    valueDisplayCache[variableId] = DisplayString(variable);
                }

                try
                {
                    DrawField(valueLabelRect, variable);    
                } catch(NullReferenceException _) {}
                
            }
            else
            {
                // No variable selected, show nothing in the value field
                //EditorGUI.LabelField(valueLabelRect, "");
            }
            
            EditorGUI.EndProperty();
        }

        /// <summary>
        /// String representation of the ScriptableVariable. Implement this method to define how the variable will be displayed in the inspector.
        /// </summary>
        /// <param name="scriptableVariable"></param>
        /// <returns></returns>
        protected abstract string DisplayString(ScriptableVariable<T> scriptableVariable);

        protected abstract void DrawField(Rect rect, ScriptableVariable<T> variable);
    }
}
