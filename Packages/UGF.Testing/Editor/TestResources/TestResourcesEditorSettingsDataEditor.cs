using System.IO;
using UGF.AssetBundles.Editor;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEngine;

namespace UGF.Testing.Editor.Editor.TestResources
{
    [CustomEditor(typeof(TestResourcesEditorSettingsData), true)]
    internal class TestResourcesEditorSettingsDataEditor : UnityEditor.Editor
    {
        private readonly AssetBundleFileDrawer m_assetBundleDrawer = new AssetBundleFileDrawer();
        private SerializedProperty m_propertyBuildBeforeTestRun;
        private SerializedProperty m_propertyClearAfterTestRun;
        private SerializedProperty m_propertyAssetBundleName;
        private SerializedProperty m_propertyAssetBundleOptions;
        private SerializedProperty m_propertyAssetBundleOutputDirectory;
        private SerializedProperty m_propertyAssetBundleOutputPath;
        private TestResourcesEditorSettingsDataFolderListDrawer m_listFolders;
        private bool m_displayAssetBundleInfo;

        private void OnEnable()
        {
            m_assetBundleDrawer.DisplayMenuClear = false;
            m_assetBundleDrawer.Enable();

            m_propertyBuildBeforeTestRun = serializedObject.FindProperty("m_buildBeforeTestRun");
            m_propertyClearAfterTestRun = serializedObject.FindProperty("m_clearAfterTestRun");
            m_propertyAssetBundleName = serializedObject.FindProperty("m_assetBundleName");
            m_propertyAssetBundleOptions = serializedObject.FindProperty("m_assetBundleOptions");
            m_propertyAssetBundleOutputDirectory = serializedObject.FindProperty("m_assetBundleOutputDirectory");
            m_propertyAssetBundleOutputPath = serializedObject.FindProperty("m_assetBundleOutputPath");

            m_listFolders = new TestResourcesEditorSettingsDataFolderListDrawer(serializedObject.FindProperty("m_folders"));
            m_listFolders.Enable();

            UpdateAssetBundleDrawer();
        }

        private void OnDisable()
        {
            m_assetBundleDrawer.Disable();
            m_listFolders.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorGUILayout.PropertyField(m_propertyBuildBeforeTestRun);
                EditorGUILayout.PropertyField(m_propertyClearAfterTestRun);
                EditorGUILayout.PropertyField(m_propertyAssetBundleName);
                EditorGUILayout.PropertyField(m_propertyAssetBundleOptions);
                EditorGUILayout.PropertyField(m_propertyAssetBundleOutputDirectory);
                EditorGUILayout.PropertyField(m_propertyAssetBundleOutputPath);

                m_listFolders.DrawGUILayout();
            }

            EditorGUILayout.Space();

            bool exists = TestResourcesEditorUtility.IsAssetBundleExists();

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                m_displayAssetBundleInfo = GUILayout.Toggle(m_displayAssetBundleInfo, "Display AssetBundle Information");

                EditorGUILayout.Space();

                using (new EditorGUI.DisabledScope(!exists))
                {
                    if (GUILayout.Button("Clear", GUILayout.Width(75F)))
                    {
                        TestResourcesEditorUtility.ClearAssetBundle();
                        AssetDatabase.Refresh();

                        UpdateAssetBundleDrawer();
                    }
                }

                using (new EditorGUI.DisabledScope(m_listFolders.SerializedProperty.arraySize == 0))
                {
                    if (GUILayout.Button("Build", GUILayout.Width(75F)))
                    {
                        TestResourcesEditorUtility.BuildAssetBundle();
                        AssetDatabase.Refresh();

                        UpdateAssetBundleDrawer();
                    }
                }

                EditorGUILayout.Space();
            }

            EditorGUILayout.Space();

            if (m_displayAssetBundleInfo)
            {
                if (m_assetBundleDrawer.HasData)
                {
                    m_assetBundleDrawer.DrawGUILayout();
                }
                else
                {
                    EditorGUILayout.HelpBox("No AssetBundle information available, build required.", MessageType.Info);
                }
            }
        }

        private void UpdateAssetBundleDrawer()
        {
            m_assetBundleDrawer.Clear();

            string path = TestResourcesEditorSettings.GetAssetBundlePath();

            if (File.Exists(path))
            {
                m_assetBundleDrawer.Set(path);
            }
        }
    }
}
