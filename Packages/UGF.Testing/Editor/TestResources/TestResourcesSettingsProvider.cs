using UGF.CustomSettings.Editor;
using UGF.Testing.Runtime.TestResources;
using UnityEditor;

namespace UGF.Testing.Editor.Editor.TestResources
{
    internal static class TestResourcesSettingsProvider
    {
        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<TestResourcesSettingsAsset>("Project/Unity Game Framework/Test Resources", TestResourcesSettings.Settings, SettingsScope.Project);
        }
    }
}
