using System;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.Butter
{
    [CreateAssetMenu(fileName = "Bool Variable", menuName = "Butter/Variables/Boolean")]
    public class BoolVariable : ScriptableVariable<bool>, IPersistentData
    {
        public string PersistencyId { get; set; }

        public string Serialize()
        {
            return Value.ToString();
        }

        public void Deserialize(string data)
        {
            Value = bool.Parse(data);
        }
        
        private void Awake()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }

    #region Custom Drawer
    [CustomPropertyDrawer(typeof(BoolVariable))]
    public class BoolVariableDrawer : VariableDrawer<bool>
    {
        protected override string DisplayString(ScriptableVariable<bool> scriptableVariable)
        {
            return $"{scriptableVariable.Value}";
        }

        protected override void DrawField(Rect rect, ScriptableVariable<bool> variable)
        {
            EditorGUI.BeginChangeCheck();
            var arg = EditorGUI.Toggle(
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