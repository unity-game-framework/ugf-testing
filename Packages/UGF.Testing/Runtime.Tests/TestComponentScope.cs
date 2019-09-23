using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public class TestComponentScope<T> : TestObjectScope<T> where T : Component
    {
        public TestComponentScope() : base(new GameObject(typeof(T).Name).AddComponent<T>())
        {
        }

        public TestComponentScope(string name) : base(new GameObject(name).AddComponent<T>())
        {
        }

        public override void Dispose()
        {
            Object.DestroyImmediate(Target.gameObject);
        }
    }
}
