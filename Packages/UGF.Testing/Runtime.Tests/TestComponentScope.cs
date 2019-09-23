using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    /// <summary>
    /// Represents a gameObject with component scope.
    /// </summary>
    public class TestComponentScope<T> : TestObjectScope<T> where T : Component
    {
        /// <summary>
        /// Creates gameObject with component of the specified type.
        /// </summary>
        public TestComponentScope() : base(new GameObject().AddComponent<T>())
        {
        }

        /// <summary>
        /// Creates gameObject with component of the specified type.
        /// </summary>
        /// <param name="name">The name of the gameObject.</param>
        public TestComponentScope(string name) : base(new GameObject(name).AddComponent<T>())
        {
        }

        public override void Dispose()
        {
            Object.DestroyImmediate(Target.gameObject);
        }
    }
}
