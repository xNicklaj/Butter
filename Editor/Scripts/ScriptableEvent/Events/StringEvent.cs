using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.Butter
{
    [CreateAssetMenu(menuName = "Butter/Events/String Event")]
    public class StringEvent : GameEvent<string>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            this.Raise(arg0);
        }
    }

    #region Drawer

    [CustomEditor(typeof(StringEvent), true)]
    public class StringEventDrawer : GameEventEditor<string>
    {
        protected override List<IGameEventListener<string>> GetListeners(Object target) => (target as StringEvent)?.Listeners;
    }
    #endregion Drawer
}