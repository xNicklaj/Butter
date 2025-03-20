using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Nicklaj.SimpleSOAP
{
    public abstract class VariableDrawer<T> : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement container = new VisualElement();

            ObjectField objectField = new ObjectField(property.displayName)
            {
                objectType = typeof(ScriptableVariable<T>)
            };
            objectField.BindProperty(property);

            Label valueLabel = new Label();
            valueLabel.style.paddingLeft = 20;
            valueLabel.style.marginBottom = 5;

            container.Add(objectField);
            container.Add(valueLabel);

            objectField.RegisterValueChangedCallback(evt =>
            {
                // Define what happens when the object field changes. Notoriusly, update the value rendered in the inspector.
                ScriptableVariable<T> currentVariable = (evt.newValue as ScriptableVariable<T>);
                if (currentVariable != null)
                {
                    valueLabel.text = this.DisplayString(currentVariable);
                    currentVariable.OnValueChanged += newValue => valueLabel.text = this.DisplayString(currentVariable);
                }
                else
                {
                    valueLabel.text = string.Empty;
                }
            });

            // Default value of the variable in the inspector
            ScriptableVariable<T> currentVariable = property.objectReferenceValue as ScriptableVariable<T>;
            if (currentVariable != null)
            {
                valueLabel.text = this.DisplayString(currentVariable);
                currentVariable.OnValueChanged += newValue => valueLabel.text = this.DisplayString(currentVariable);
            }

            return container;
        }

        /// <summary>
        /// String representation of the ScriptableVariable. Implement this method to define how the variable will be displayed in the inspector.
        /// </summary>
        /// <param name="scriptableVariable"></param>
        /// <returns></returns>
        protected abstract string DisplayString(ScriptableVariable<T> scriptableVariable);
    }
}