using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(menuName = "Simple SOAP/Events/Vector2 Event")]
    public class Vector2Event : GameEvent<Vector2>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            // Try to parse the input as a vector2
            var tmp = arg0.Replace("(", "").Replace(")", "").Split((", "));
            if (float.TryParse(tmp[0], out var x) == false || float.TryParse(tmp[1], out var y) == false) return;
            this.Raise(new Vector2(x,y));
        }
    }
    
    #region Drawer
    [CustomEditor(typeof(Vector2Event), true)]
    public class Vector2EventDrawer : GameEventEditor<Vector2>
    {
        protected override List<IGameEventListener<Vector2>> GetListeners(Object target) => (target as Vector2Event)?.Listeners;
    }
    #endregion Drawer
}