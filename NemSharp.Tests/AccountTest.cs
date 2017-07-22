using System;
using NemSharp.Models;
using NemSharp.Request.Responses;
using NUnit.Framework;

namespace NemSharp.Tests
{
    [TestFixture]
    public class AccountTest : TestBase
    {
        [Test]
        public void TestGenerate()
        {
            KeyPairViewModel result = Client.Account.GenerateLocal(0x98);

            Console.WriteLine(result.Address);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PrivateKey);
            Assert.IsNotNull(result.PublicKey);
            Assert.IsNotNull(result.Address);
        }
    }
}
