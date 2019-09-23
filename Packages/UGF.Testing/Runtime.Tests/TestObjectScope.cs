using System;
using Object = UnityEngine.Object;

namespace UGF.Testing.Runtime.Tests
{
    public class TestObjectScope : IDisposable
    {
        public Object Target { get; }

        public TestObjectScope(Object target)
        {
            Target = target ? target : throw new ArgumentNullException(nameof(target));
        }

        public virtual void Dispose()
        {
            Object.DestroyImmediate(Target);
        }
    }
}
