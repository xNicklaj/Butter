using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{

    /// <summary>
    /// Base Runtime Set class. Extend this to create your scriptable list that will act
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RuntimeSetBase<T> : RuntimeScriptableObject, IRuntimeSet
    {
        /// <summary>
        /// Item set.
        /// </summary>
        [NonSerialized] public List<T> Items = new List<T>();


        public void Add(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
                
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
        
        protected override void OnReset()
        {
            if (Items != null && Items.Count > 0)
                Items.Clear();
        }
    }
}