using System;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    /// <summary>
    /// Represents the scope to control 'Debug.unityLogger'.
    /// </summary>
    public struct TestLogScope : IDisposable
    {
        private readonly bool m_enabled;

        /// <summary>
        /// Creates test log scope.
        /// </summary>
        /// <param name="enabled">The value that determines whether to enable 'Debug.unityLogger'.</param>
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
