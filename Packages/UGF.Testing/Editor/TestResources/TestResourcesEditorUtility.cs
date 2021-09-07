using System;
using System.Collections.Generic;
using System.IO;
using UGF.AssetBundles.Editor;
using UnityEditor;
using UnityEngine;

namespace UGF.Testing.Editor.Editor.TestResources
{
    public static class TestResourcesEditorUtility
    {
        public static AssetBundleManifest BuildAssetBundle()
        {
            return BuildAssetBundle(EditorUserBuildSettings.activeBuildTarget);
        }

        public static AssetBundleManifest BuildAssetBundle(BuildTarget buildTarget)
        {
            TestResourcesEditorSettingsData settings = TestResourcesEditorSettings.Settings.GetData();
            AssetBundleBuildInfo build = GetAssetBundleBuildInfo(settings.AssetBundleName, settings.Folders);
            string outputPath = TestResourcesEditorSettings.GetAssetBundleOutputPath();

            Directory.CreateDirectory(outputPath);

            return AssetBundleBuildUtility.Build(new[] { build }, outputPath, buildTarget, settings.AssetBundleOptions);
        }

        public static bool IsAssetBundleExists()
        {
            string path = TestResourcesEditorSettings.GetAssetBundlePath();

            return File.Exists(path);
        }

        public static void ClearAssetBundle()
        {
            string outputPath = TestResourcesEditorSettings.GetAssetBundleOutputPath();
            string metaPath = $"{outputPath}.meta";

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }

            if (File.Exists(metaPath))
            {
                File.Delete(metaPath);
            }
        }

        public static AssetBundleBuildInfo GetAssetBundleBuildInfo(string assetBundleName, IReadOnlyList<string> folders)
        {
            if (string.IsNullOrEmpty(assetBundleName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetBundleName));
            if (folders == null) throw new ArgumentNullException(nameof(folders));

            var assets = new Dictionary<string, string>();

            GetAssets(assets, folders);

            var info = new AssetBundleBuildInfo(assetBundleName);

            foreach (KeyValuePair<string, string> pair in assets)
            {
                info.AddAsset(pair.Key, pair.Value);
            }

            return info;
        }

        public static void GetAssets(IDictionary<string, string> assets, IReadOnlyList<string> folders)
        {
            if (assets == null) throw new ArgumentNullException(nameof(assets));
            if (folders == null) throw new ArgumentNullException(nameof(folders));

            for (int i = 0; i < folders.Count; i++)
            {
                string folderPath = folders[i];
                string[] guids = AssetDatabase.FindAssets(string.Empty, new[] { folderPath });

                foreach (string guid in guids)
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(guid);

                    if (!AssetDatabase.IsValidFolder(assetPath))
                    {
                        string addressRoot = Path.GetDirectoryName(folderPath);

                        string addressPath = !string.IsNullOrEmpty(addressRoot)
                            ? assetPath.Substring(addressRoot.Length + 1, assetPath.Length - addressRoot.Length - 1)
                            : assetPath;

                        string addressName = Path.GetFileNameWithoutExtension(addressPath);
                        string addressDirectory = Path.GetDirectoryName(addressPath);
                        string address = !string.IsNullOrEmpty(addressDirectory) ? $"{addressDirectory}/{addressName}" : addressName;

                        address = address.Replace('\\', '/');

                        assets.Add(address, assetPath);
                    }
                }
            }
        }
    }
}
