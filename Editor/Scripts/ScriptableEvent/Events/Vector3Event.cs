using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.Butter
{
    [CreateAssetMenu(menuName = "Butter/Events/Vector3 Event")]
    public class Vector3Event : GameEvent<Vector3>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            // Try to parse the input as a vector2
            var tmp = arg0.Replace("(", "").Replace(")", "").Split((", "));
            if (float.TryParse(tmp[0], out var x) == false || float.TryParse(tmp[1], out var y) == false || float.TryParse(tmp[2], out var z) == false) return;
            this.Raise(new Vector3(x,y,z));
        }
    }
    
    #region Drawer
    [CustomEditor(typeof(Vector3Event), true)]
    public class Vector3EventDrawer : GameEventEditor<Vector3>
    {
        protected override List<IGameEventListener<Vector3>> GetListeners(Object target) => (target as Vector3Event)?.Listeners;
    }
    #endregion Drawer
}