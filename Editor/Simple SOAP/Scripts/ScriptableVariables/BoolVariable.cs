using UnityEditor;

namespace Nicklaj.SimpleSOAP
{
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