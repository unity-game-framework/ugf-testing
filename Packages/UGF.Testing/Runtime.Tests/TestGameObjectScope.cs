using System;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    /// <summary>
    /// Represents a gameObject scope.
    /// </summary>
    public class TestGameObjectScope : TestObjectScope<GameObject>
    {
        /// <summary>
        /// Creates empty gameObject without components.
        /// </summary>
        public TestGameObjectScope() : base(new GameObject())
        {
        }

        /// <summary>
        /// Creates empty gameObject with specified name.
        /// </summary>
        /// <param name="name">The name of the gameObject.</param>
        public TestGameObjectScope(string name) : base(new GameObject(name))
        {
        }

        /// <summary>
        /// Creates gameObject with the specified name and components.
        /// </summary>
        /// <param name="name">The name of the gameObject.</param>
        /// <param name="components">The collection of the components.</param>
        public TestGameObjectScope(string name, params Type[] components) : base(new GameObject(name, components))
        {
        }
    }
}
