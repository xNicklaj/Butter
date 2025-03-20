using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace Nicklaj.SimpleSOAP
{
    public class ListVariable<T> : ScriptableVariable<List<T>> { }

    #region Specific Implementations

    [CreateAssetMenu(fileName = "Game Objects List Variable", menuName = "SOAP/Variables/Game Objects List")]
    public class GameObjectListVariable : ListVariable<GameObject> { }

    [CreateAssetMenu(fileName = "Integer List Variable", menuName = "SOAP/Variables/Integer List")]
    public class IntegerListVariable : ListVariable<int> { }

    [CreateAssetMenu(fileName = "Float List Variable", menuName = "SOAP/Variables/Float List")]
    public class FloatListVariable : ListVariable<float> { }

    [CreateAssetMenu(fileName = "Bool List Variable", menuName = "SOAP/Variables/Integer List")]
    public class BoolListVariable : ListVariable<bool> { }

    #endregion
}
// How do I serialize this?