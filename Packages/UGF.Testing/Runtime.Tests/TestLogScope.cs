using System;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public struct TestLogScope : IDisposable
    {
        private readonly bool m_enabled;

        public TestLogScope(bool enabled)
        {
            m_enabled = Debug.unityLogger.logEnabled;

            Debug.unityLogger.logEnabled = enabled;
        }

        public void Dispose()
        {
            Debug.unityLogger.logEnabled = m_enabled;
        }
    }
}
