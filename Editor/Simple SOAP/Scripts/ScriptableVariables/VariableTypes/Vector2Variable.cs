using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(fileName = "Vector2 Variable", menuName = "Simple SOAP/Variables/Vector2")]
    public class Vector2Variable : ScriptableVariable<Vector2>, IPersistentData
    {
        public string PersistencyId { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Value);
        }

        public void Deserialize(string data)
        {
            Value = JsonConvert.DeserializeObject<Vector2>(data);
        }
        
        private void Awake()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }
    
    #region Custom Drawer
    [CustomPropertyDrawer(typeof(Vector2Variable))]
    public class Vector2VariableDrawer : VariableDrawer<Vector2>
    {
        protected override string DisplayString(ScriptableVariable<Vector2> scriptableVariable)
        {
            return $"{scriptableVariable.Value}";
        }
        
        protected override void DrawField(Rect rect, ScriptableVariable<Vector2> variable)
        {
            EditorGUI.BeginChangeCheck();
            var arg = EditorGUI.Vector2Field(
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