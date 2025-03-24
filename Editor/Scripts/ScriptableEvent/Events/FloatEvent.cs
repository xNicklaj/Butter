using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{
    [CreateAssetMenu(menuName = "Butter/Events/Float Event")]
    public class FloatEvent : GameEvent<float>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            // Try to parse the input as a float
            if (float.TryParse(arg0, NumberStyles.Float, CultureInfo.InvariantCulture, out float result) == false) return;
            this.Raise(result);
        }
    }

    #region Drawer

    [CustomEditor(typeof(FloatEvent), true)]
    public class FloatEventDrawer : GameEventEditor<float>
    {
        protected override List<IGameEventListener<float>> GetListeners(Object target) => (target as FloatEvent)?.Listeners;
    }
    #endregion Drawer
}
