using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests.Tests
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
            using (new TestLogScope(true))
            {
                Debug.Log("Enabled()");
            }

            Assert.True(m_logReceived);
        }

        [Test]
        public void Disabled()
        {
            using (new TestLogScope(false))
            {
                Debug.Log("Disabled()");
            }

            Assert.False(m_logReceived);
        }
    }
}
