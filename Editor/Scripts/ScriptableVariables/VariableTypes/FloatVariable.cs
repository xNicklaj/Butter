using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;


namespace Nicklaj.Butter
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Butter/Variables/Float")]
    public class FloatVariable : ScriptableVariable<float>, IPersistentData
    {
        public string PersistencyId { get; set; }

        public string Serialize()
        {
            return Value.ToString();
        }

        public void Deserialize(string data)
        {
            Value = float.Parse(data);
        }
        
        private void Awake()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }


    #region Custom Drawer
    [CustomPropertyDrawer(typeof(FloatVariable))]
    public class FloatVariableDrawer : VariableDrawer<float>
    {
        protected override string DisplayString(ScriptableVariable<float> scriptableVariable)
        {
            return $"{scriptableVariable.Value}";
        }
        
        protected override void DrawField(Rect rect, ScriptableVariable<float> variable)
        {
            EditorGUI.BeginChangeCheck();
            var arg = EditorGUI.FloatField(
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