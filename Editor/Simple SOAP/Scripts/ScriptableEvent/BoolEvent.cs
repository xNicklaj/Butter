using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(menuName = "Simple SOAP/Events/Boolean Event")]
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
    public class BoolEventDrawer : SerializedRaiseEditor { }
    #endregion Drawer
}
