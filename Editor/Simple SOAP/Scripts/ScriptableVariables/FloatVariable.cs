using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;


namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Simple SOAP/Variables/Float")]
    public class FloatVariable : ScriptableVariable<float>, ISaveScriptableData
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
            return $"Current Value: {scriptableVariable.Value}";
        }
    }
    #endregion
}