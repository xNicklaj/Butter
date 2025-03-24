using System;
using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{
    [CreateAssetMenu(fileName = "String Variable", menuName = "Butter/Variables/String")]
    public class StringVariable : ScriptableVariable<string>, IPersistentData
    {
        public string PersistencyId { get; set; }

        public string Serialize()
        {
            return Value;
        }

        public void Deserialize(string data)
        {
            Value = data;
        }
        
        private void Awake()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }
    
    #region Custom Drawer
    [CustomPropertyDrawer(typeof(StringVariable))]
    public class StringVariableDrawer : VariableDrawer<string>
    {
        protected override string DisplayString(ScriptableVariable<string> scriptableVariable)
        {
            return $"{scriptableVariable.Value}";
        }
        
        protected override void DrawField(Rect rect, ScriptableVariable<string> variable)
        {
            EditorGUI.BeginChangeCheck();
            var arg = EditorGUI.TextField(
                rect,
                "Value",
                variable.Value
            );
            if (EditorGUI.EndChangeCheck())
            {
                variable.Value = arg;    
            }
        }
    }
    #endregion
}