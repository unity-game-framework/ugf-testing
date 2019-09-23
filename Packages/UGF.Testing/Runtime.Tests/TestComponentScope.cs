using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public class TestComponentScope<T> : TestObjectScope where T : Component
    {
        public T Component { get { return (T)Target; } }

        public TestComponentScope() : base(new GameObject(typeof(T).Name).AddComponent<T>())
        {
        }

        public TestComponentScope(string name) : base(new GameObject(name).AddComponent<T>())
        {
        }

        public override void Dispose()
        {
            Object.DestroyImmediate(Component.gameObject);
        }
    }
}
