using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Coroutines.Runtime;
using UnityEditor;

namespace UGF.Module.Coroutines.Editor
{
    [CustomEditor(typeof(CoroutineModuleAsset), true)]
    internal class CoroutineModuleAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyDefaultExecuter;
        private AssetIdReferenceListDrawer m_listExecuters;
        private ReorderableListSelectionDrawerByPath m_listExecutersSelection;

        private void OnEnable()
        {
            m_propertyDefaultExecuter = serializedObject.FindProperty("m_defaultExecuter");

            m_listExecuters = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_executers"))
            {
                DisplayAsSingleLine = true
            };

            m_listExecutersSelection = new ReorderableListSelectionDrawerByPath(m_listExecuters, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listExecuters.Enable();
            m_listExecutersSelection.Enable();
        }

        private void OnDisable()
        {
            m_listExecutersSelection.Disable();
            m_listExecuters.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyDefaultExecuter);

                m_listExecuters.DrawGUILayout();
                m_listExecutersSelection.DrawGUILayout();
            }
        }
    }
}
