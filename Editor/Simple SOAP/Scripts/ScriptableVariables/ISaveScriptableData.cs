using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    public interface ISaveScriptableData
    {
        public string PersistencyId { get; set; }
        public string Serialize();
        public void Deserialize(string data);
    }
}