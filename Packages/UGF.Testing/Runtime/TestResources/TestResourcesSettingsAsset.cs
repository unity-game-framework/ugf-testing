using UGF.CustomSettings.Runtime;
using UGF.RuntimeTools.Runtime.Storage;
using UnityEngine;

namespace UGF.Testing.Runtime.TestResources
{
    public class TestResourcesSettingsAsset : CustomSettingsData
    {
        [SerializeField] private StoragePathType m_assetBundleDirectory = StoragePathType.StreamingAssets;
        [SerializeField] private string m_assetBundlePath = "Testing/TestResources";

        public StoragePathType AssetBundleDirectory { get { return m_assetBundleDirectory; } set { m_assetBundleDirectory = value; } }
        public string AssetBundlePath { get { return m_assetBundlePath; } set { m_assetBundlePath = value; } }
    }
}
