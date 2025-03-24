using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;

namespace Dev.Nicklaj.Butter
{
    public abstract class ScriptableVariable<T> : RuntimeScriptableObject
    {
        [SerializeField] T _initialValue;
        [SerializeField] T _value;

        public UnityAction<T> OnValueChanged = delegate { };

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