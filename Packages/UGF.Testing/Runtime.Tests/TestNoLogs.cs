using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public abstract class TestNoLogs
    {
        [OneTimeSetUp]
        public virtual void SetupAll()
        {
            Debug.unityLogger.logEnabled = false;
        }

        [OneTimeTearDown]
        public virtual void TeardownAll()
        {
            Debug.unityLogger.logEnabled = true;
        }
    }
}
