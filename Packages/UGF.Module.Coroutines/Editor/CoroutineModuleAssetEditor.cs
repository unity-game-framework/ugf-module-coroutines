using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Coroutines.Runtime;
using UnityEditor;

namespace UGF.Module.Coroutines.Editor
{
    [CustomEditor(typeof(CoroutineModuleAsset), true)]
    internal class CoroutineModuleAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScript;
        private SerializedProperty m_propertyDefaultExecuter;
        private AssetReferenceListDrawer m_listExecuters;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");
            m_propertyDefaultExecuter = serializedObject.FindProperty("m_defaultExecuter");
            m_listExecuters = new AssetReferenceListDrawer(serializedObject.FindProperty("m_executers"));

            m_listExecuters.Enable();
        }

        private void OnDisable()
        {
            m_listExecuters.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(m_propertyScript);
                }

                EditorGUILayout.PropertyField(m_propertyDefaultExecuter);

                m_listExecuters.DrawGUILayout();
            }
        }
    }
}
