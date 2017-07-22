using NemSharp.Request.Objects;
using NUnit.Framework;

namespace NemSharp.Tests
{
    [TestFixture]
    public class AccountTest : TestBase
    {
        [Test]
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
