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
            Client = new NemClient("http://188.68.50.161:7890");
        }
    }
}