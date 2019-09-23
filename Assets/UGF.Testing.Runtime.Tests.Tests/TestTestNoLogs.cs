using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.Tests
{
    public class TestTestNoLogs : TestNoLogs
    {
        private bool m_logReceived;

        public override void SetupAll()
        {
            base.SetupAll();

            Application.logMessageReceived += OnApplicationLogMessageReceived;
        }

        public override void TeardownAll()
        {
            base.TeardownAll();

            Application.logMessageReceived -= OnApplicationLogMessageReceived;
        }

        [TearDown]
        public void Teardown()
        {
            m_logReceived = false;
        }

        private void OnApplicationLogMessageReceived(string condition, string stacktrace, LogType type)
        {
            m_logReceived = true;
        }

        [Test]
        public void NoLogs()
        {
            Debug.Log("NoLogs()");

            Assert.False(m_logReceived);
        }
    }
}
