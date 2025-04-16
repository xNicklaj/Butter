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
}