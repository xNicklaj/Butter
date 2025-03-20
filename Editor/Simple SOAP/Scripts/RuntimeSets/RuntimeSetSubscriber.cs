
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    public class RuntimeSetSubscriber : MonoBehaviour
    {
        [SerializeField] private GameObjectRuntimeSet _runtimeSet;

        private void OnEnable() => _runtimeSet?.Add(this.gameObject);
        private void OnDisable() => _runtimeSet?.Remove(this.gameObject);
    }
}