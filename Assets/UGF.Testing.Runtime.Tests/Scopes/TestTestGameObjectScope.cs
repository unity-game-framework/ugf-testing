using NUnit.Framework;
using UGF.Testing.Runtime.Scopes;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.Scopes
{
    public class TestTestGameObjectScope
    {
        [Test]
        public void Scope()
        {
            GameObject target;

            using (var scope = new TestGameObjectScope("GameObject"))
            {
                target = scope.Target;

                Assert.True(target != null);
                Assert.AreEqual("GameObject", target.name);
            }

            Assert.True(target == null);
        }
    }
}
