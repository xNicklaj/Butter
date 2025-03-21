using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(menuName = "Simple SOAP/Events/Integer Event")]
    public class IntEvent : GameEvent<int>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            if (int.TryParse(arg0, out int result) == false) return;
            this.Raise(result);
        }
    }

    #region Drawer

    [CustomEditor(typeof(IntEvent), true)]
    public class IntEventDrawer : GameEventEditor<int>
    {
        protected override List<IGameEventListener<int>> GetListeners(Object target) => (target as IntEvent)?.Listeners;
    }
    #endregion Drawer
}