using UnityEngine;

namespace UGF.Testing.Runtime.Scopes
{
    /// <summary>
    /// Represents a scriptableObject scope.
    /// </summary>
    public class TestScriptableObjectScope<T> : TestObjectScope<T> where T : ScriptableObject
    {
        /// <summary>
        /// Creates scriptableObject of the specified type.
        /// </summary>
        public TestScriptableObjectScope() : base(ScriptableObject.CreateInstance<T>())
        {
        }

        /// <summary>
        /// Creates scriptableObject with the specified name.
        /// </summary>
        /// <param name="name">The name of the scriptableObject.</param>
        public TestScriptableObjectScope(string name) : base(ScriptableObject.CreateInstance<T>())
        {
            Target.name = name;
        }
    }
}
