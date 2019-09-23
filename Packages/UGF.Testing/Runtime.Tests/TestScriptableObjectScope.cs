using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public class TestScriptableObjectScope<T> : TestObjectScope<T> where T : ScriptableObject
    {
        public TestScriptableObjectScope() : base(ScriptableObject.CreateInstance<T>())
        {
            Target.name = typeof(T).Name;
        }

        public TestScriptableObjectScope(string name) : base(ScriptableObject.CreateInstance<T>())
        {
            Target.name = name;
        }
    }
}
