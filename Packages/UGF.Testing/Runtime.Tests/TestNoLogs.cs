using NUnit.Framework;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public abstract class TestNoLogs
    {
        [SetUp]
        public virtual void Setup()
        {
            Debug.unityLogger.logEnabled = false;
        }

        [TearDown]
        public virtual void TearDown()
        {
            Debug.unityLogger.logEnabled = true;
        }
    }
}
