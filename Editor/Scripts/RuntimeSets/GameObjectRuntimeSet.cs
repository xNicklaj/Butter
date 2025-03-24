using UnityEditor;
using UnityEngine;

namespace Dev.Nicklaj.Butter
{
    [CreateAssetMenu(menuName = "Butter/Runtime Sets/GameObject Runtime Set")]
    public class GameObjectRuntimeSet : RuntimeSetBase<GameObject>
    {

    }
    
    #region Custom Editor
    [CustomEditor(typeof(GameObjectRuntimeSet), true)]
    public class GameObjectRuntimeSetDrawer : RuntimeSetDrawer<GameObject>
    {
        public override void DrawItems()
        {
            foreach (GameObject item in (target as GameObjectRuntimeSet).Items)
            {
                EditorGUILayout.ObjectField(item, typeof(GameObject), true);
            }
        }
    }
    #endregion
}