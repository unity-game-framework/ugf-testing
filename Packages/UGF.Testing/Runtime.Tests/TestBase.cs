using NUnit.Framework;

namespace UGF.Testing.Runtime.Tests
{
    /// <summary>
    /// Represents base test with default setup and teardown methods.
    /// </summary>
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void SetupAll()
        {
        }

        [OneTimeTearDown]
        public virtual void TeardownAll()
        {
        }

        [SetUp]
        public virtual void Setup()
        {
        }

        [TearDown]
        public virtual void Teardown()
        {
        }
    }
}
