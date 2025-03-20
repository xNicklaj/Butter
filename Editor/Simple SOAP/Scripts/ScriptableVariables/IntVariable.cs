using System;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP 
{
    [CreateAssetMenu(fileName = "Int Variable", menuName = "Simple SOAP/Variables/Integer")]
    public class IntVariable : ScriptableVariable<int>, ISaveScriptableData
    {
        public string PersistencyId { get; set; }

        public string Serialize()
        {
            return Value.ToString();
        }

        public void Deserialize(string data)
        {
            Value = int.Parse(data);
        }
        
        private void Awake()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }

    #region Custom Drawer
    [CustomPropertyDrawer(typeof(IntVariable))]
    public class IntVariableDrawer : VariableDrawer<int>
    {
        protected override string DisplayString(ScriptableVariable<int> scriptableVariable)
        {
            return $"Current Value: {scriptableVariable.Value}";
        }
    }
    #endregion
}