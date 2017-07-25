using System;
using System.Collections.Generic;
using System.Linq;
using NemSharp.Data;
using NemSharp.Models;
using NemSharp.Request;
using NemSharp.Request.Responses;
using NemSharp.Request.Responses.Account;
using NemSharp.Request.Responses.Namespace;
using NemSharp.Request.Responses.Transaction;
using NUnit.Framework;

namespace NemSharp.Tests
{
    [TestFixture]
    public class AccountTest : TestBase
    {
        private string generatePrivateKey = "04e7e06420ace9f6bab010565fcbfcb0b502ba7bb00387665644c096e9c158f4";

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
        public void TestCreateTestAddress()
        {
            string expectedPublicKey = "686349a360c7bec565cb15de1358b106f83f098e38c473eb237d24608e268fd5";
            string expectedAddress = "TC5SVELWEUWA3R2IEZ34337GGZTETKTESUKDSFPS";

            KeyPairViewModel result = Account.GenerateFromPrivateKey(generatePrivateKey, Networks.TestNet.Prefix);

            Assert.AreEqual(result.PublicKey, expectedPublicKey);
            Assert.AreEqual(result.Address, expectedAddress);
        }

        [Test]
        public void TestCreateMainAddress()
        {
            string expectedPublicKey = "686349a360c7bec565cb15de1358b106f83f098e38c473eb237d24608e268fd5";
            string expectedAddress = "NC5SVELWEUWA3R2IEZ34337GGZTETKTESWQNTHCK";

            KeyPairViewModel result = Account.GenerateFromPrivateKey(generatePrivateKey, Networks.MainNet.Prefix);

            Assert.AreEqual(result.PublicKey, expectedPublicKey);
            Assert.AreEqual(result.Address, expectedAddress);
        }

        [Test]
        public void TestGetByAddress()
        {
            AccountMetaDataPair result = Client.Account.GetAccountByAddress(TestConstants.ACCOUNT_ADDRESS1);

            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.MetaData);

            Assert.AreEqual(result.Account.PublicKey, TestConstants.ACCOUNT_PUBLIC_KEY1);
        }

        [Test]
        public void TestGetByPublicKey()
        {
            AccountMetaDataPair result = Client.Account.GetAccountByPublicKey(TestConstants.ACCOUNT_PUBLIC_KEY1);

            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.MetaData);

            Assert.AreEqual(result.Account.Address, TestConstants.ACCOUNT_ADDRESS1);
        }

        [Test]
        public void TestGetForwardedAccountByAddress()
        {
            AccountMetaDataPair result = Client.Account.GetForwardedAccountByAddress(TestConstants.ACCOUNT_DELEGATED_ADDRESS1);

            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.MetaData);

            Assert.AreEqual(result.Account.Address, TestConstants.ACCOUNT_DELEGATED_ADDRESS1);
        }

        [Test]
        public void TestGetForwardedAccountByPublicKey()
        {
            AccountMetaDataPair result = Client.Account.GetForwardedAccountByPublicKey(TestConstants.ACCOUNT_DELEGATED_PUBLIC_KEY1);

            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.MetaData);

            Assert.AreEqual(result.Account.Address, TestConstants.ACCOUNT_DELEGATED_ADDRESS1);
        }

        [Test]
        public void TestGetAccountStatus()
        {
            AccountMetaData result = Client.Account.GetStatus(TestConstants.ACCOUNT_ADDRESS1);

            Assert.IsNotNull(result.Status);
        }

        [Test]
        public void TestGetAccountTransfersIncoming()
        {
            DataArray<TransactionMetaDataPair> result = Client.Account.GetTransfersIncoming(TestConstants.ACCOUNT_ADDRESS1);

            Assert.Greater(result.Data.Count, 0);
            Assert.GreaterOrEqual(result.Data.First().Transaction.Fee, 0);
            Assert.GreaterOrEqual(result.Data.First().Transaction.Amount, 0);
            Assert.Greater(result.Data.First().Meta.Height, 0);
        }

        [Test]
        public void TestGetAccountTransfersOutgoing()
        {
            DataArray<TransactionMetaDataPair> result = Client.Account.GetTransfersOutgoing(TestConstants.ACCOUNT_ADDRESS1);

            Assert.Greater(result.Data.Count, 0);
            Assert.GreaterOrEqual(result.Data.First().Transaction.Fee, 0);
            Assert.GreaterOrEqual(result.Data.First().Transaction.Amount, 0);
            Assert.Greater(result.Data.First().Meta.Height, 0);
        }

        [Test]
        public void TestGetAccountTransfersAll()
        {
            DataArray<TransactionMetaDataPair> result = Client.Account.GetTransfersAll(TestConstants.ACCOUNT_ADDRESS1);

            Assert.Greater(result.Data.Count, 0);
            Assert.GreaterOrEqual(result.Data.First().Transaction.Fee, 0);
            Assert.GreaterOrEqual(result.Data.First().Transaction.Amount, 0);
            Assert.Greater(result.Data.First().Meta.Height, 0);
        }

        [Test]
        public void TestGetAccountImportances()
        {
            DataArray<AccountImportanceViewModel> result = Client.Account.GetImportances(TestConstants.ACCOUNT_ADDRESS1);

            foreach (AccountImportanceViewModel viewModel in result.Data)
            {
                if (viewModel.Importance.IsSet > 0)
                {
                    Assert.GreaterOrEqual(viewModel.Importance.Height, 1);
                }
            }
        }

        [Test]
        public void TestGetAccountNamespaces()
        {
            DataArray<Namespace> result = Client.Account.GetNamespaces(TestConstants.ACCOUNT_ADDRESS1);

            CollectionAssert.Contains(
                    result.Data,
                    new Namespace
                    {
                        NamespaceID = "nemsharp.test",
                        Height = 1045839,
                        Owner = TestConstants.ACCOUNT_ADDRESS1
                    }
                );

            CollectionAssert.Contains(
                    result.Data,
                    new Namespace
                    {
                        NamespaceID = "nemsharp",
                        Height = 1045839,
                        Owner = TestConstants.ACCOUNT_ADDRESS1
                    }
                );
        }

        [Test]
        public void TestGetAccountParentNamespaces()
        {
            DataArray<Namespace> result = Client.Account.GetNamespaces(TestConstants.ACCOUNT_ADDRESS1,
                new RequestParameter
                {
                    Name = "parent",
                    Value = "nemsharp"
                });

            CollectionAssert.Contains(
                result.Data,
                new Namespace
                {
                    NamespaceID = "nemsharp.test",
                    Height = 1045839,
                    Owner = TestConstants.ACCOUNT_ADDRESS1
                }
            );
        }

    }
}