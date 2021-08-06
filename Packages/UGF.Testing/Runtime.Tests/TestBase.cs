using NUnit.Framework;

namespace UGF.Testing.Runtime.Tests
{
    /// <summary>
    /// Represents base test with default setup and teardown methods.
    /// </summary>
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void OnSetupAll()
        {
        }

        [OneTimeTearDown]
        public virtual void OnTeardownAll()
        {
        }

        [SetUp]
        public virtual void OnSetup()
        {
        }

        [TearDown]
        public virtual void OnTeardown()
        {
        }
    }
}
