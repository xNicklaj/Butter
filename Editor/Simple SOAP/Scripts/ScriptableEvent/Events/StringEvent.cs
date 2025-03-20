using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(menuName = "Simple SOAP/Events/String Event")]
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
    public class StringEventDrawer : SerializedRaiseEditor { }
    #endregion Drawer
}