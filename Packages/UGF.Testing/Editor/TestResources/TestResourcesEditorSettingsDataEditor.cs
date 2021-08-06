using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEngine;

namespace UGF.Testing.Editor.Editor.TestResources
{
    [CustomEditor(typeof(TestResourcesEditorSettingsData), true)]
    internal class TestResourcesEditorSettingsDataEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyBuildOnTestsPlayerBuild;
        private SerializedProperty m_propertyClearAfterTestsPlayerBuild;
        private SerializedProperty m_propertyAssetBundleName;
        private SerializedProperty m_propertyAssetBundleOptions;
        private SerializedProperty m_propertyAssetBundleOutputDirectory;
        private SerializedProperty m_propertyAssetBundleOutputPath;
        private TestResourcesEditorSettingsDataFolderListDrawer m_listFolders;

        private void OnEnable()
        {
            m_propertyBuildOnTestsPlayerBuild = serializedObject.FindProperty("m_buildOnTestsPlayerBuild");
            m_propertyClearAfterTestsPlayerBuild = serializedObject.FindProperty("m_clearAfterTestsPlayerBuild");
            m_propertyAssetBundleName = serializedObject.FindProperty("m_assetBundleName");
            m_propertyAssetBundleOptions = serializedObject.FindProperty("m_assetBundleOptions");
            m_propertyAssetBundleOutputDirectory = serializedObject.FindProperty("m_assetBundleOutputDirectory");
            m_propertyAssetBundleOutputPath = serializedObject.FindProperty("m_assetBundleOutputPath");

            m_listFolders = new TestResourcesEditorSettingsDataFolderListDrawer(serializedObject.FindProperty("m_folders"));
            m_listFolders.Enable();
        }

        private void OnDisable()
        {
            m_listFolders.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorGUILayout.PropertyField(m_propertyBuildOnTestsPlayerBuild);
                EditorGUILayout.PropertyField(m_propertyClearAfterTestsPlayerBuild);
                EditorGUILayout.PropertyField(m_propertyAssetBundleName);
                EditorGUILayout.PropertyField(m_propertyAssetBundleOptions);
                EditorGUILayout.PropertyField(m_propertyAssetBundleOutputDirectory);
                EditorGUILayout.PropertyField(m_propertyAssetBundleOutputPath);

                m_listFolders.DrawGUILayout();
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                using (new EditorGUI.DisabledScope(!TestResourcesEditorUtility.IsAssetBundleExists()))
                {
                    if (GUILayout.Button("Clear", GUILayout.Width(75F)))
                    {
                        TestResourcesEditorUtility.ClearAssetBundle();
                        AssetDatabase.Refresh();
                    }
                }

                using (new EditorGUI.DisabledScope(m_listFolders.SerializedProperty.arraySize == 0))
                {
                    if (GUILayout.Button("Build", GUILayout.Width(75F)))
                    {
                        TestResourcesEditorUtility.BuildAssetBundle();
                        AssetDatabase.Refresh();
                    }
                }

                EditorGUILayout.Space();
            }
        }
    }
}
