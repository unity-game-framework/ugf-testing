using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public abstract class TestCollectLogs
    {
        protected List<LogEntry> Logs { get; } = new List<LogEntry>();

        protected struct LogEntry
        {
            public string Condition;
            public string Stacktrace;
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
        }

        [TearDown]
        public void Teardown()
        {
            Logs.Clear();
        }

        protected virtual void OnApplicationLogMessageReceived(string condition, string stacktrace, LogType type)
        {
            var entry = new LogEntry
            {
                Condition = condition,
                Stacktrace = stacktrace,
                Type = type
            };

            Logs.Add(entry);
        }
    }
}
