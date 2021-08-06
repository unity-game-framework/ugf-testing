using System;
using System.IO;
using System.Threading.Tasks;
using UGF.AssetBundles.Runtime;
using UGF.RuntimeTools.Runtime.Tasks;
using Object = UnityEngine.Object;

namespace UGF.Testing.Runtime.TestResources
{
    public static class TestResourcesProvider
    {
        public static AssetBundleHandler Handler { get; }

        static TestResourcesProvider()
        {
            string path = TestResourcesSettings.GetAssetBundlePath();

            Handler = new AssetBundleHandler(path);

            if (File.Exists(Handler.Path))
            {
                Handler.Load();
            }
        }

        public static T Load<T>(string path) where T : Object
        {
            return (T)Load(path, typeof(T));
        }

        public static Object Load(string path, Type type)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (type == null) throw new ArgumentNullException(nameof(type));

            Object asset = Handler.AssetBundle.LoadAsset(path, type);

            return asset ? asset : throw new ArgumentException($"Asset not found by the specified path and type: '{path}', '{type}'.");
        }

        public static async Task<T> LoadAsync<T>(string path) where T : Object
        {
            return (T)await LoadAsync(path, typeof(T));
        }

        public static async Task<object> LoadAsync(string path, Type type)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            if (type == null) throw new ArgumentNullException(nameof(type));

            Object asset = await Handler.AssetBundle.LoadAssetAsync(path, type).WaitAsync();

            return asset ? asset : throw new ArgumentException($"Asset not found by the specified path and type: '{path}', '{type}'.");
        }
    }
}
