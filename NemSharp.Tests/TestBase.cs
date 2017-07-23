using NUnit.Framework;

namespace NemSharp.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        public NemClient Client;

        [SetUp]
        public void Initialize()
        {
            Client = new NemClient("http://bob.nem.ninja:7890");
        }
    }
}