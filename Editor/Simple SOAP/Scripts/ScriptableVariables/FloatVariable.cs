using UnityEditor;
using UnityEngine;


namespace Nicklaj.SimpleSOAP
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "SOAP/Variables/Float")]
    public class FloatVariable : ScriptableVariable<float>
    {

    }


    #region Custom Drawer
    [CustomPropertyDrawer(typeof(FloatVariable))]
    public class FloatVariableDrawer : VariableDrawer<float>
    {
        protected override string DisplayString(ScriptableVariable<float> scriptableVariable)
        {
            return $"Current Value: {scriptableVariable.Value}";
        }
    }
    #endregion
}