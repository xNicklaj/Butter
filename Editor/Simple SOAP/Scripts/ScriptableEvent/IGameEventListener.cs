using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    public interface IGameEventListener<T>
    {
        public GameObject Target { get; set; }
        void OnEventRaised(T data);
    }

}