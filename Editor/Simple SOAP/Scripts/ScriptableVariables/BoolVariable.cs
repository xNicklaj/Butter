using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(fileName = "Bool Variable", menuName = "Simple SOAP/Variables/Boolean")]
    public class BoolVariable : ScriptableVariable<bool> { }

    #region Custom Drawer
    [CustomPropertyDrawer(typeof(BoolVariable))]
    public class BoolVariableDrawer : VariableDrawer<bool>
    {
        protected override string DisplayString(ScriptableVariable<bool> scriptableVariable)
        {
            return $"Current Value: {scriptableVariable.Value}";
        }
    }
    #endregion
}