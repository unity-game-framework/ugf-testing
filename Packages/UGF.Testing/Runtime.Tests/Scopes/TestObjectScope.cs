using System;
using Object = UnityEngine.Object;

namespace UGF.Testing.Runtime.Tests.Scopes
{
    /// <summary>
    /// Represents a object scope of the specified type.
    /// </summary>
    public class TestObjectScope<T> : IDisposable where T : Object
    {
        /// <summary>
        /// Gets the target of the scope.
        /// </summary>
        public T Target { get; }

        /// <summary>
        /// Creates scope with the specified object.
        /// </summary>
        /// <param name="target">The object.</param>
        public TestObjectScope(T target)
        {
            Target = target ? target : throw new ArgumentNullException(nameof(target));
        }

        public virtual void Dispose()
        {
            Object.DestroyImmediate(Target);
        }
    }
}
