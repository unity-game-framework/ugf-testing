using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    /// <summary>
    /// Represents test with Unity Logs collect for each test separately.
    /// </summary>
    public abstract class TestCollectLogs
    {
        /// <summary>
        /// Gets collection of the collected logs for the single test.
        /// </summary>
        protected IReadOnlyList<LogEntry> Logs { get { return m_logs; } }

        /// <summary>
        /// Gets collection of the collection logs for all tests.
        /// </summary>
        protected IReadOnlyList<LogEntry> LogsAll { get { return m_logsAll; } }

        private readonly List<LogEntry> m_logs = new List<LogEntry>();
        private readonly List<LogEntry> m_logsAll = new List<LogEntry>();

        /// <summary>
        /// Represents entry of the log.
        /// </summary>
        protected struct LogEntry
        {
            /// <summary>
            /// A condition of the log.
            /// </summary>
            public string Condition;

            /// <summary>
            /// A stacktrace of the log.
            /// </summary>
            public string Stacktrace;

            /// <summary>
            /// The type of the log.
            /// </summary>
            public LogType Type;
        }

        [OneTimeSetUp]
        public virtual void SetupAll()
        {
            Application.logMessageReceived += OnApplicationLogMessageReceived;
        }

        [OneTimeTearDown]
        public virtual void TeardownAll()
        {
            Application.logMessageReceived -= OnApplicationLogMessageReceived;

            m_logsAll.Clear();
        }

        [TearDown]
        public void Teardown()
        {
            m_logs.Clear();
        }

        /// <summary>
        /// Clears logs collected for current test.
        /// </summary>
        protected void ClearLogs()
        {
            m_logs.Clear();
        }

        /// <summary>
        /// Clears logs collected for all tests.
        /// </summary>
        protected void ClearLogsAll()
        {
            m_logsAll.Clear();
        }

        private void OnApplicationLogMessageReceived(string condition, string stacktrace, LogType type)
        {
            var entry = new LogEntry
            {
                Condition = condition,
                Stacktrace = stacktrace,
                Type = type
            };

            m_logs.Add(entry);
            m_logsAll.Add(entry);
        }
    }
}
