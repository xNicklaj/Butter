using System;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(fileName = "String Variable", menuName = "Simple SOAP/Variables/String")]
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
            return $"Current Value: {scriptableVariable.Value}";
        }
    }
    #endregion
}