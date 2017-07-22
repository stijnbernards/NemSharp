using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemSharp.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        public NemClient Client;

        [TestInitialize]
        public void Initialize()
        {
            Client = new NemClient("http://127.0.0.1:7890");
        }
    }
}
