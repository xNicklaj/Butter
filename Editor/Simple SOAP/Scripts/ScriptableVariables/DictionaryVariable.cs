using System.Collections.Generic;
using UnityEngine.Events;

namespace Nicklaj.SimpleSOAP
{
    /// <summary>
    /// Extendable class for creating dictionary variables.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionaryVariable<TKey, TValue> : ScriptableVariable<Dictionary<TKey, TValue>>
    {
        public UnityAction OnItemAdded = delegate { };
        public UnityAction OnItemRemoved = delegate { };

        /// <summary>
        /// Adds a new key-value pair to the dictionary and invokes the OnItemAdded event.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            Value.Add(key, value);
            OnItemAdded.Invoke();
        }

        /// <summary>
        /// Removes a key-value pair from the dictionary and invokes the OnItemRemoved event.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key)
        {
            Value.Remove(key);
            OnItemRemoved.Invoke();
        }
    }
}