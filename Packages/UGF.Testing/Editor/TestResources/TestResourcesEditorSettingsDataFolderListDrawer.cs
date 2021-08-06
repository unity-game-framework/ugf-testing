using System;
using UGF.EditorTools.Editor.IMGUI;
using UnityEditor;
using UnityEngine;

namespace UGF.Testing.Editor.Editor.TestResources
{
    internal class TestResourcesEditorSettingsDataFolderListDrawer : ReorderableListDrawer
    {
        private Styles m_styles;

        private class Styles
        {
            public GUIContent ButtonContent { get; } = new GUIContent(EditorGUIUtility.FindTexture("_Menu"));
            public GUIStyle ButtonStyle { get; } = new GUIStyle("IconButton");
        }

        public TestResourcesEditorSettingsDataFolderListDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
        {
        }

        protected override void OnDrawGUI(Rect position, GUIContent label = null)
        {
            m_styles ??= new Styles();

            base.OnDrawGUI(position, label);
        }

        protected override void OnDrawElementContent(Rect position, SerializedProperty serializedProperty, int index, bool isActive, bool isFocused)
        {
            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;

            var rectPath = new Rect(position.x, position.y, position.width - height - space, position.height);
            var rectButton = new Rect(rectPath.xMax + space, position.y, height, position.height);

            EditorGUI.PropertyField(rectPath, serializedProperty, GUIContent.none);

            if (GUI.Button(rectButton, m_styles.ButtonContent, m_styles.ButtonStyle))
            {
                serializedProperty.stringValue = SelectPath(serializedProperty.stringValue);
                serializedProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        protected override float OnElementHeightContent(SerializedProperty serializedProperty, int index)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        private string SelectPath(string path)
        {
            string directory = Environment.CurrentDirectory;
            string selected = EditorUtility.OpenFolderPanel("Select Folder", "Assets", string.Empty);

            if (!string.IsNullOrEmpty(selected))
            {
                selected = selected.Substring(directory.Length + 1, selected.Length - directory.Length - 1);

                path = selected;
            }

            return path;
        }
    }
}
