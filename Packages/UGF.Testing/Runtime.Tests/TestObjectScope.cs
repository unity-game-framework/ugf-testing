using System;
using Object = UnityEngine.Object;

namespace UGF.Testing.Runtime.Tests
{
    public class TestObjectScope<T> : IDisposable where T : Object
    {
        public T Target { get; }

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
