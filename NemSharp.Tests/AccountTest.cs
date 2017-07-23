using System;
using NemSharp.Data;
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
            KeyPairViewModel result = Account.GenerateLocal(Networks.TestNet.Prefix);

            Console.WriteLine("Address: " + result.Address);
            Console.WriteLine("publicKey: " + result.PublicKey);
            Console.WriteLine("privateKey: " + result.PrivateKey);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PrivateKey);
            Assert.IsNotNull(result.PublicKey);
            Assert.IsNotNull(result.Address);
        }

        [Test]
        public void TestCreateAddress()
        {
            string privateKey = "04e7e06420ace9f6bab010565fcbfcb0b502ba7bb00387665644c096e9c158f4";

            string expectedPublicKey = "686349a360c7bec565cb15de1358b106f83f098e38c473eb237d24608e268fd5";
            string expectedAddress = "TC5SVELWEUWA3R2IEZ34337GGZTETKTESUKDSFPS";

            KeyPairViewModel result = Account.GenerateFromPrivateKey(privateKey, Networks.TestNet.Prefix);

            Assert.AreEqual(result.PublicKey, expectedPublicKey);
            Assert.AreEqual(result.Address, expectedAddress);
        }

        [Test]
        public void TestGetByAddress()
        {
            AccountMetaDataPair result = Client.Account.GetAccountByAddress(TestConstants.ACCOUNT_ADDRESS1);

            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.MetaData);
        }
    }
}
