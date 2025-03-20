using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(menuName = "Simple SOAP/Events/Float Event")]
    public class FloatEvent : GameEvent<float>, ISerializedRaise
    {
        public bool HasArgument => true;

        public void OnRaiseButtonSubmit(string arg0 = "")
        {
            // Try to parse the input as a float
            if (float.TryParse(arg0, out float result) == false) return;
            this.Raise(result);
        }
    }
}
