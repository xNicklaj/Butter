using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{
    [CreateAssetMenu(fileName = "Vector3 Variable", menuName = "Butter/Variables/Vector3")]
    public class Vector3Variable : ScriptableVariable<Vector3>, IPersistentData
    {
        public string PersistencyId { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Value);
        }

        public void Deserialize(string data)
        {
            Value = JsonConvert.DeserializeObject<Vector3>(data);
        }
        
        private void Awake()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }
    
    #region Custom Drawer
    [CustomPropertyDrawer(typeof(Vector3Variable))]
    public class Vector3VariableDrawer : VariableDrawer<Vector3>
    {
        protected override string DisplayString(ScriptableVariable<Vector3> scriptableVariable)
        {
            return $"{scriptableVariable.Value}";
        }
        
        protected override void DrawField(Rect rect, ScriptableVariable<Vector3> variable)
        {
            EditorGUI.BeginChangeCheck();
            var arg = EditorGUI.Vector3Field(
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