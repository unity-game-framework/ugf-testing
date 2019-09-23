using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Testing.Runtime.Tests.Tests
{
    public class TestTestObjectScope
    {
        [Test]
        public void Scope()
        {
            Object target = new GameObject();

            using (var scope = new TestObjectScope<Object>(target))
            {
                Assert.True(scope.Target != null);
            }

            Assert.True(target == null);
        }
    }
}
