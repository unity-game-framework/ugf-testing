using UGF.CustomSettings.Runtime;
using UGF.RuntimeTools.Runtime.Storage;

namespace UGF.Testing.Runtime.TestResources
{
    public static class TestResourcesSettings
    {
        public static CustomSettingsPackage<TestResourcesSettingsAsset> Settings { get; } = new CustomSettingsPackage<TestResourcesSettingsAsset>
        (
            "UGF.Testing",
            nameof(TestResourcesSettings)
        );

        public static string GetAssetBundlePath()
        {
            TestResourcesSettingsAsset data = Settings.GetData();
            string path = StorageUtility.GetPath(data.AssetBundleDirectory, data.AssetBundlePath);

            return path;
        }
    }
}
