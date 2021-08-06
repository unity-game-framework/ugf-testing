using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public class TestTestNoLogs : TestNoLogs
    {
        private bool m_logReceived;

        public override void OnSetupAll()
        {
            base.OnSetupAll();

            Application.logMessageReceived += OnApplicationLogMessageReceived;
        }

        public override void OnTeardownAll()
        {
            base.OnTeardownAll();

            Application.logMessageReceived -= OnApplicationLogMessageReceived;
        }

        public override void OnTeardown()
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
