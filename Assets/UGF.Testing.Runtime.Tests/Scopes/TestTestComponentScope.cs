using NUnit.Framework;
using UGF.Testing.Runtime.Scopes;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.Scopes
{
    public class TestTestComponentScope
    {
        private class Target : MonoBehaviour
        {
        }

        [Test]
        public void Scope()
        {
            Target target;

            using (var scope = new TestComponentScope<Target>("Target"))
            {
                target = scope.Target;

                Assert.True(target != null);
                Assert.AreEqual("Target", scope.Target.gameObject.name);
            }

            Assert.True(target == null);
        }
    }
}
