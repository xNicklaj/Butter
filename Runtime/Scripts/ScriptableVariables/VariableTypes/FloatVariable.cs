using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;


namespace Dev.Nicklaj.Butter
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
}