using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

namespace Nicklaj.SimpleSOAP
{
    /// <summary>
    /// Generic GameEvent that will send a data of type T when raised. Couples with GameEventListener.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameEvent<T> : ScriptableObject
    {
        protected readonly List<IGameEventListener<T>> listeners = new();
        public List<IGameEventListener<T>> Listeners => listeners;

        public void Raise(T data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(data);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener) => listeners.Add(listener);
        public void DeregisterListener(IGameEventListener<T> listener) => listeners.Remove(listener);
    }

    /// <summary>
    /// Non-generic version of GameEvent. You can use this version when the event you want to raise doesn't need to have any data associated with it.
    /// </summary>
    [CreateAssetMenu(menuName = "Simple SOAP/Events/Game Event")]
    public class GameEvent : GameEvent<Unit>, ISerializedRaise
    {
        public bool HasArgument => false;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            Raise();
        }

        public void Raise() => Raise(Unit.Default);
    }

    #region Drawer
    [CustomEditor(typeof(GameEvent), true)]
    public class GameEventDrawer : GameEventEditor<Unit>
    {
        protected override List<IGameEventListener<Unit>> GetListeners(Object target) => (target as GameEvent)?.Listeners;
    }
    #endregion Drawer

    public struct Unit
    {
        public static Unit Default => default;
    }
}

