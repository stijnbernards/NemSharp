using Microsoft.VisualStudio.TestTools.UnitTesting;
using NemSharp.Request.Objects;

namespace NemSharp.Tests
{
    [TestClass]
    public class AccountTest : TestBase
    {
        [TestMethod]
        public void TestGenerate()
        {
            KeyPairViewModel result = Client.Account.Generate();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PrivateKey);
            Assert.IsNotNull(result.PublicKey);
            Assert.IsNotNull(result.Address);
        }
    }
}
