using UGF.Testing.Editor.Editor.TestResources;
using UnityEditor.TestTools;
using UnityEngine.TestTools;

[assembly: PrebuildSetup(typeof(TestResourcesEditorBuildPreprocessor))]

namespace UGF.Testing.Editor.Editor.TestResources
{
    [RequirePlatformSupport]
    internal class TestResourcesEditorBuildPreprocessor : IPrebuildSetup
    {
        public void Setup()
        {
            TestResourcesEditorSettingsData settings = TestResourcesEditorSettings.Settings.GetData();

            if (settings.BuildBeforeTestRun)
            {
                TestResourcesEditorUtility.BuildAssetBundle();
            }
        }
    }
}
