using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(menuName = "SOAP/Events/Integer Event")]
    public class IntEvent : GameEvent<int>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            if (int.TryParse(arg0, out int result) == false) return;
            this.Raise(result);
        }
    }
}