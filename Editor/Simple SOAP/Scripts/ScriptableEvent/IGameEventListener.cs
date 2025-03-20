using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T data);
    }

}