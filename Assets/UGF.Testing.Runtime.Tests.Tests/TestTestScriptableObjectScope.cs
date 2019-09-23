using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.Tests
{
    public class TestTestScriptableObjectScope
    {
        private class Target : ScriptableObject
        {
        }

        [Test]
        public void Scope()
        {
            ScriptableObject target;

            using (var scope = new TestScriptableObjectScope<Target>("ScriptableObject"))
            {
                target = scope.Target;

                Assert.True(target != null);
                Assert.AreEqual("ScriptableObject", target.name);
            }

            Assert.True(target == null);
        }
    }
}
