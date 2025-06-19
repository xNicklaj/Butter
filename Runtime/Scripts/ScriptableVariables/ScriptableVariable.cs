using System;
using Newtonsoft.Json;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Events;

namespace Dev.Nicklaj.Butter
{
    public abstract class ScriptableVariable<T> : RuntimeScriptableObject
    {
        [SerializeField] T _initialValue;
        [SerializeField] T _value;

        public UnityAction<T> OnValueChanged = delegate { };

        [CreateProperty]
        public T Value
        {
            get => _value;
            set
            {
                if (this._value.Equals(value)) return;
                this._value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        /// <summary>
        /// Manually reset variable to initial state.
        /// </summary>
        public void Reset() => OnReset();

        [Obsolete("This should only be used when creating new scriptable variables, avoid calling this directly through code otherwise, it's here just for compatibility reasons.")]
        protected override void OnReset()
        {
            OnValueChanged?.Invoke(_value = _initialValue);
        }
    }
}

public enum ResetOn
{
    SceneLoaded,
    ApplicationStart,
    None
}