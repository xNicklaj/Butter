using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dev.Nicklaj.Butter
{
    public class PersistentDataManager : MonoBehaviour
    {
        public PersistentDataMasterList persistentDataMasterList;

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