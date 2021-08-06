using NUnit.Framework;
using UGF.Testing.Runtime.TestResources;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.TestResources
{
    public class TestTestResources
    {
        [Test]
        public void HasAssetBundleLoaded()
        {
            bool result = TestResourcesProvider.Handler.HasAssetBundle;

            Assert.True(result);
        }

        [Test]
        public void LoadBlue()
        {
            var result = TestResourcesProvider.Load<Material>("Folder0/TestMaterial");

            Assert.NotNull(result);
            Assert.AreEqual("TestMaterial", result.name);
            Assert.AreEqual(Color.blue, result.color);
        }

        [Test]
        public void LoadRed()
        {
            var result = TestResourcesProvider.Load<Material>("Folder1/TestMaterial");

            Assert.NotNull(result);
            Assert.AreEqual("TestMaterial", result.name);
            Assert.AreEqual(Color.red, result.color);
        }

        [Test]
        public void LoadGreen()
        {
            var result = TestResourcesProvider.Load<Material>("Folder0/Nested/TestMaterial");

            Assert.NotNull(result);
            Assert.AreEqual("TestMaterial", result.name);
            Assert.AreEqual(Color.green, result.color);
        }
    }
}
