using UGF.Testing.Editor.Editor.TestResources;
using UnityEditor.TestTools;
using UnityEngine.TestTools;

[assembly: PostBuildCleanup(typeof(TestResourcesEditorBuildPostprocessor))]

namespace UGF.Testing.Editor.Editor.TestResources
{
    [RequirePlatformSupport]
    internal class TestResourcesEditorBuildPostprocessor : IPostBuildCleanup
    {
        public void Cleanup()
        {
            TestResourcesEditorSettingsData settings = TestResourcesEditorSettings.Settings.GetData();

            if (settings.ClearAfterTestsPlayerBuild)
            {
                TestResourcesEditorUtility.ClearAssetBundle();
            }
        }
    }
}
