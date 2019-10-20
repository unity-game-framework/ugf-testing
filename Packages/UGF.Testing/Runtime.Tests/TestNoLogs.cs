using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    /// <summary>
    /// Represents test without any 'Debug.unityLogger' logs.
    /// </summary>
    public abstract class TestNoLogs : TestBase
    {
        public override void SetupAll()
        {
            Debug.unityLogger.logEnabled = false;
        }

        public override void TeardownAll()
        {
            Debug.unityLogger.logEnabled = true;
        }
    }
}
