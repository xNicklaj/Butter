using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.Butter
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
        /// <summary>
        /// List with the names of all elements. Note that this doesn't grant you access to the elements itself, it's just a quick and dirty way to visualize them in the inspector. For the actual references get Items.
        /// </summary>
        public List<string> ItemNames = new List<string>();

        public void Add(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
                ItemNames.Add(item.ToString());
            }
                
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                ItemNames.Remove(item.ToString());
            }
        }
        
        protected override void OnReset()
        {
            if (Items != null && Items.Count > 0)
                Items.Clear();
            if(ItemNames != null && ItemNames.Count > 0)
                ItemNames.Clear();
        }
    }

    [CreateAssetMenu(menuName = "Butter/Runtime Sets/GameObject Runtime Set")]
    public class GameObjectRuntimeSet : RuntimeSetBase<GameObject>
    {

    }

    #region Custom Editor
    [CustomEditor(typeof(RuntimeSetBase<GameObject>), true)]
    public class GameObjectRuntimeSetDrawer : RuntimeSetDrawer { }
    #endregion
}