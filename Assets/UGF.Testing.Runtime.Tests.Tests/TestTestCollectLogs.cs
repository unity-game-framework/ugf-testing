using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.Tests
{
    public class TestTestCollectLogs : TestCollectLogs
    {
        [Test]
        public void Collect1()
        {
            Debug.Log("Collect1()");

            Assert.AreEqual(1, Logs.Count);
            Assert.True(Logs.Exists(x => x.Condition == "Collect1()"));
        }

        [Test]
        public void Collect2()
        {
            Debug.Log("Collect2()");

            Assert.AreEqual(1, Logs.Count);
            Assert.True(Logs.Exists(x => x.Condition == "Collect2()"));
        }
    }
}
