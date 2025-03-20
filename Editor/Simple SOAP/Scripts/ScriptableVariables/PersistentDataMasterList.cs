using System;
using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor.Overlays;
using UnityEngine;
using System.IO;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(fileName = "Persistent Data", menuName = "Simple SOAP/Persistent Data Master List")]
    public class PersistentDataMasterList : ScriptableObject
    {
        public string SavePath;
        public List<ScriptableObject> List = new();

        private string _finalPath = "";
        
        public void SaveData()
        {
            if (!SanityCheck()) return;
            string data = SerializeData();
            File.WriteAllText(_finalPath, data);
            Debug.Log($"Saving data to {_finalPath}");
        }

        public void LoadData()
        {
            if (!SanityCheck()) return;
            string data = File.ReadAllText(_finalPath);
            DeserializeData(data);
            
        }

        private string SerializeData()
        {
            Dictionary<string, string> JsonEncoded = new();
            foreach (var variable in List)
            {
                if (variable is not ISaveScriptableData scriptableObject)
                {
                    Debug.LogWarning("Variable " + variable.name + " is not ISaveScriptableData. Skipping variable.");
                    continue;
                }
                string data = (variable as ISaveScriptableData).Serialize();
                JsonEncoded.Add((variable as ISaveScriptableData).PersistencyId, data);
            }
            return JsonConvert.SerializeObject(JsonEncoded);
        }

        private void DeserializeData(string data)
        {
            Dictionary<string, string> JsonEncoded = new();
            JsonEncoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            foreach (var variable in List)
            {
                if (variable is not ISaveScriptableData scriptableObject)
                {
                    Debug.LogWarning("Variable " + variable.name + " is not ISaveScriptableData. Skipping variable.");
                    continue;
                }
                (variable as ISaveScriptableData).Deserialize(JsonEncoded[(variable as ISaveScriptableData).PersistencyId]);
            }
        }


        private void OnValidate()
        {
            _finalPath = Path.Join(Application.persistentDataPath, SavePath);
            if(!_finalPath.EndsWith(".json"))
                _finalPath += ".json";
        }

        private bool SanityCheck()
        {
            if (string.IsNullOrEmpty(SavePath))
            {
                Debug.LogWarning("No Save Path set. Ignoring MasterList.");
                return false;
            }

            return true;
        }
    }
}