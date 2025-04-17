using System;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{
    [CreateAssetMenu(fileName = "Vector3 Variable", menuName = "Butter/Variables/Vector3")]
    public class Vector3Variable : ScriptableVariable<Vector3>, IPersistentData
    {
        [field: SerializeField, HideInInspector] public string PersistencyId { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Value);
        }

        public void Deserialize(string data)
        {
            Value = JsonConvert.DeserializeObject<Vector3>(data);
        }
        
        private void OnValidate()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }
}