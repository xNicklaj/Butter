using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.Butter
{
    [CreateAssetMenu(menuName = "Butter/Events/Boolean Event")]
    public class BoolEvent : GameEvent<bool>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            // Try to parse the input as a boolean
            if (bool.TryParse(arg0, out bool result) == false) return;
            this.Raise(result);
        }
    }

    #region Drawer

    [CustomEditor(typeof(BoolEvent), true)]
    public class BoolEventDrawer : GameEventEditor<bool>
    {
        protected override List<IGameEventListener<bool>> GetListeners(Object target) => (target as BoolEvent)?.Listeners;
    }
    #endregion Drawer
}
