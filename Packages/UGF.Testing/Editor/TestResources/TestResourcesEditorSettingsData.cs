using System.Collections.Generic;
using UGF.CustomSettings.Runtime;
using UGF.RuntimeTools.Runtime.Storage;
using UnityEditor;
using UnityEngine;

namespace UGF.Testing.Editor.Editor.TestResources
{
    public class TestResourcesEditorSettingsData : CustomSettingsData
    {
        [SerializeField] private bool m_buildBeforeTestRun = true;
        [SerializeField] private bool m_clearAfterTestRun = true;
        [SerializeField] private string m_assetBundleName = "TestResources";
        [SerializeField] private BuildAssetBundleOptions m_assetBundleOptions = BuildAssetBundleOptions.None;
        [SerializeField] private StoragePathType m_assetBundleOutputDirectory = StoragePathType.StreamingAssets;
        [SerializeField] private string m_assetBundleOutputPath = "Testing";
        [SerializeField] private List<string> m_folders = new List<string>();

        public bool BuildBeforeTestRun { get { return m_buildBeforeTestRun; } set { m_buildBeforeTestRun = value; } }
        public bool ClearAfterTestRun { get { return m_clearAfterTestRun; } set { m_clearAfterTestRun = value; } }
        public string AssetBundleName { get { return m_assetBundleName; } set { m_assetBundleName = value; } }
        public BuildAssetBundleOptions AssetBundleOptions { get { return m_assetBundleOptions; } set { m_assetBundleOptions = value; } }
        public StoragePathType AssetBundleOutputDirectory { get { return m_assetBundleOutputDirectory; } set { m_assetBundleOutputDirectory = value; } }
        public string AssetBundleOutputPath { get { return m_assetBundleOutputPath; } set { m_assetBundleOutputPath = value; } }
        public List<string> Folders { get { return m_folders; } }
    }
}
