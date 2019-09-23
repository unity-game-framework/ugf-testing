using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public class TestScriptableObjectScope<T> : TestObjectScope where T : ScriptableObject
    {
        public T ScriptableObject { get { return (T)Target; } }

        public TestScriptableObjectScope() : base(UnityEngine.ScriptableObject.CreateInstance<T>())
        {
            Target.name = typeof(T).Name;
        }

        public TestScriptableObjectScope(string name) : base(UnityEngine.ScriptableObject.CreateInstance<T>())
        {
            Target.name = name;
        }
    }
}
