using NUnit.Framework;
using UGF.Testing.Runtime.Tests.Scopes;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.Tests.Scopes
{
    public class TestTestLogScope
    {
        private bool m_logReceived;

        [OneTimeSetUp]
        public void SetupAll()
        {
            Application.logMessageReceived += OnApplicationLogMessageReceived;
        }

        [OneTimeTearDown]
        public void TeardownAll()
        {
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
        public void Default()
        {
            Debug.Log("Default()");

            Assert.True(m_logReceived);
        }

        [Test]
        public void Enabled()
        {
            using (new TestLogEnableScope(true))
            {
                Debug.Log("Enabled()");
            }

            Assert.True(m_logReceived);
        }

        [Test]
        public void Disabled()
        {
            using (new TestLogEnableScope(false))
            {
                Debug.Log("Disabled()");
            }

            Assert.False(m_logReceived);
        }
    }
}
