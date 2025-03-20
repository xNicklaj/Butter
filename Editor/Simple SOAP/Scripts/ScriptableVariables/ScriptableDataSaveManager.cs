using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Serialization;

namespace Nicklaj.SimpleSOAP
{
    public class ScriptableDataSaveManager : MonoBehaviour
    {
        [FormerlySerializedAs("scriptableDataMasterList")] public PersistentDataMasterList persistentDataMasterList;

        public void SaveData()
        {
            if (persistentDataMasterList == null) return;
            persistentDataMasterList.SaveData();
        }

        public void LoadData()
        {
            if (persistentDataMasterList == null) return;
            persistentDataMasterList.LoadData();
        }
    }
}