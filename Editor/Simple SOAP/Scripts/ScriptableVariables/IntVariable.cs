using System;
using UnityEditor;
using UnityEngine;

namespace Nicklaj.SimpleSOAP 
{
    [CreateAssetMenu(fileName = "Int Variable", menuName = "Simple SOAP/Variables/Integer")]
    public class IntVariable : ScriptableVariable<int> { }

    #region Custom Drawer
    [CustomPropertyDrawer(typeof(IntVariable))]
    public class IntVariableDrawer : VariableDrawer<int>
    {
        protected override string DisplayString(ScriptableVariable<int> scriptableVariable)
        {
            return $"Current Value: {scriptableVariable.Value}";
        }
    }
    #endregion
}