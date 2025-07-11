﻿using System;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{
    [CreateAssetMenu(fileName = "Vector2 Variable", menuName = "Butter/Variables/Vector2")]
    public class Vector2Variable : ScriptableVariable<Vector2>, IPersistentData
    {
        [field: SerializeField, HideInInspector] public string PersistencyId { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Value, new JsonSerializerSettings(){ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        }

        public void Deserialize(string data)
        {
            Value = JsonConvert.DeserializeObject<Vector2>(data, new JsonSerializerSettings(){ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        }
        
        private void OnValidate()
        {
            if(string.IsNullOrEmpty(PersistencyId))
                PersistencyId = Guid.NewGuid().ToString();
        }
    }
}