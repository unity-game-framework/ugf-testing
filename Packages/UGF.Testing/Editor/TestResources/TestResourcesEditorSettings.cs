using System.IO;
using UGF.CustomSettings.Editor;
using UGF.RuntimeTools.Runtime.Storage;
using UnityEditor;

namespace UGF.Testing.Editor.Editor.TestResources
{
    public static class TestResourcesEditorSettings
    {
        public static CustomSettingsEditorPackage<TestResourcesEditorSettingsData> Settings { get; } = new CustomSettingsEditorPackage<TestResourcesEditorSettingsData>
        (
            "UGF.Testing",
            nameof(TestResourcesEditorSettings)
        );

        public static string GetAssetBundlePath()
        {
            TestResourcesEditorSettingsData data = Settings.GetData();
            string path = StorageUtility.GetPath(data.AssetBundleOutputDirectory, data.AssetBundleOutputPath);

            path = Path.Combine(path, data.AssetBundleName);

            return path;
        }

        public static string GetAssetBundleOutputPath()
        {
            TestResourcesEditorSettingsData data = Settings.GetData();
            string path = StorageUtility.GetPath(data.AssetBundleOutputDirectory, data.AssetBundleOutputPath);

            return path;
        }

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<TestResourcesEditorSettingsData>("Project/Unity Game Framework/Test Resources Editor", Settings, SettingsScope.Project);
        }
    }
}
