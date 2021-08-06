using System;
using UnityEngine;

namespace UGF.Testing.Runtime.Scopes
{
    /// <summary>
    /// Represents the scope to control 'Debug.unityLogger'.
    /// </summary>
    public readonly struct TestLogEnableScope : IDisposable
    {
        private readonly bool m_enabled;

        /// <summary>
        /// Creates test log scope.
        /// </summary>
        /// <param name="enabled">The value that determines whether to enable 'Debug.unityLogger'.</param>
        public TestLogEnableScope(bool enabled)
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
