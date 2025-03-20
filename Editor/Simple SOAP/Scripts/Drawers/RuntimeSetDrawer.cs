using UnityEngine;
using UnityEditor;

namespace Nicklaj.SimpleSOAP
{
    public class RuntimeSetDrawer : Editor
    {
        private IRuntimeSet raiseTarget;
        private bool isRaiseTarget = false;
        
        private void OnEnable()
        {
            // Check if target implements ISerializedRaise
            raiseTarget = target as IRuntimeSet;
            isRaiseTarget = raiseTarget != null;
        }

        public override void OnInspectorGUI()
        {
            // Draw the default inspector
            DrawDefaultInspector();
            if (!isRaiseTarget) return;
            EditorGUILayout.HelpBox($"This list is for debug and visualization purposes only, as Scriptables cannot serialize runtime data. Do not modify.", MessageType.Info);
        }
    }
}