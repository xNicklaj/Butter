

using System.Collections.Generic;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{

    /// <summary>
    /// Base Runtime Set class. Extend this to create your scriptable list that will act
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RuntimeSetBase<T> : RuntimeScriptableObject
    {
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            if (!Items.Contains(item))
                Items.Add(item);
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }


    }

    [CreateAssetMenu(menuName = "Simple SOAP/Runtime Sets/GameObject Runtime Set")]
    public class GameObjectRuntimeSet : RuntimeSetBase<GameObject>
    {
        protected override void OnReset()
        {
            if (Items != null && Items.Count > 0)
                Items.Clear();
        }
    }
}