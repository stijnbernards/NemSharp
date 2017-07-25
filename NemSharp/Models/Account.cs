using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Albireo.Base32;
using Chaos.NaCl;
using NemSharp.Request;
using NemSharp.Request.Responses;
using NemSharp.Request.Responses.Account;
using NemSharp.Request.Responses.Namespace;
using NemSharp.Request.Responses.Transaction;
using Org.BouncyCastle.Crypto.Digests;
using RestSharp;

namespace NemSharp.Models
{
    public class Account : ModelBase
    {
        private const string GENERATE_PATH = "/account/generate";
        private const string GET_BY_ADDRESS_PATH = "/account/get";
        private const string GET_BY_PUBLIC_KEY_PATH = "/account/get/from-public-key";
        private const string GET_FORWARDED_BY_ADDRESS_PATH = "/account/get/forwarded";
        private const string GET_FORWARDED_BY_PUBLIC_KEY = "/account/get/forwarded/from-public-key";
        private const string ACCOUNT_STATUS_PATH = "/account/status";
        private const string ACCOUNT_TRANSFERS_INCOMING_PATH = "/account/transfers/incoming";
        private const string ACCOUNT_TRANSFERS_OUTGOING_PATH = "/account/transfers/outgoing";
        private const string ACCOUNT_TRANSFERS_ALL_PATH = "/account/transfers/all";
        private const string ACCOUNT_IMPORTANCES_PATH = "/account/importances";
        private const string ACCOUNT_NAMESPACE_PAGE_PATH = "/account/namespace/page";

        #region Generation
        public static KeyPairViewModel GenerateFromPrivateKey(string privateKey, int networkPrefix)
        {
            byte[] privateKeyBytes = CryptoBytes.FromHexString(privateKey);

            return GenerateFromPrivateKey(privateKeyBytes, networkPrefix);
        }

        public static KeyPairViewModel GenerateFromPrivateKey(byte[] privateKey, int networkPrefix)
        {
            Array.Reverse(privateKey);
            byte[] publicKey = Ed25519.PublicKeyFromSeed(privateKey);
            Array.Reverse(privateKey);

            string address = PublicKeyToAddress(publicKey, networkPrefix);

            return new KeyPairViewModel(CryptoBytes.ToHexStringLower(privateKey), CryptoBytes.ToHexStringLower(publicKey), address);
        }

        public static KeyPairViewModel GenerateLocal(int networkPrefix)
        {
            byte[] privateKey = new byte[32];

            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(privateKey);
            }

            return GenerateFromPrivateKey(privateKey, networkPrefix);
        }

        public static string PublicKeyToAddress(byte[] publicKey, int networkPrefix)
        {
            KeccakDigest shaDigest = new KeccakDigest(256);
            byte[] bytesFirst = new byte[32];

            shaDigest.BlockUpdate(publicKey, 0, 32);
            shaDigest.DoFinal(bytesFirst, 0);

            RipeMD160Digest digestRipeMd160 = new RipeMD160Digest();
            byte[] bytesSecond = new byte[20];

            digestRipeMd160.BlockUpdate(bytesFirst, 0, 32);
            digestRipeMd160.DoFinal(bytesSecond, 0);

            byte[] bytesThird = CryptoBytes.FromHexString(
                    string.Concat(networkPrefix,
                    CryptoBytes.ToHexStringLower(bytesSecond))
                );

            byte[] bytesFourth = new byte[32];

            shaDigest.BlockUpdate(bytesThird, 0, 21);
            shaDigest.DoFinal(bytesFourth, 0);

            byte[] bytesFifth = new byte[4];
            Array.Copy(bytesFourth, 0, bytesFifth, 0, 4);

            byte[] bytesSixth = new byte[25];
            Array.Copy(bytesThird, 0, bytesSixth, 0, 21);
            Array.Copy(bytesFifth, 0, bytesSixth, 21, 4);

            return Base32.Encode(bytesSixth).ToUpper();
        }

        #endregion

        public Account(RestClient client) : base(client)
        {
            
        }

        public KeyPairViewModel GenerateFromNode()
        {
            RestRequest request = Builder.BuildRequest(GENERATE_PATH);

            return Client.Execute<KeyPairViewModel>(request).Data;
        }

        public AccountMetaDataPair GetAccountByAddress(string address)
        {
            RestRequest request = Builder.BuildRequest(
                    GET_BY_ADDRESS_PATH,
                    new RequestParameter
                    {
                        Name = "address",
                        Value = address
                    }
                );

            return Client.Execute<AccountMetaDataPair>(request).Data;
        }

        public AccountMetaDataPair GetAccountByPublicKey(string publicKey)
        {
            RestRequest request = Builder.BuildRequest(
                    GET_BY_PUBLIC_KEY_PATH,
                    new RequestParameter
                    {
                        Name = "publicKey",
                        Value = publicKey
                    }
                );

            return Client.Execute<AccountMetaDataPair>(request).Data;
        }

        public AccountMetaDataPair GetForwardedAccountByAddress(string address)
        {
            RestRequest request = Builder.BuildRequest(
                    GET_FORWARDED_BY_ADDRESS_PATH,
                    new RequestParameter
                    {
                        Name = "address",
                        Value = address
                    }
                );

            return Client.Execute<AccountMetaDataPair>(request).Data;
        }

        public AccountMetaDataPair GetForwardedAccountByPublicKey(string publicKey)
        {
            RestRequest request = Builder.BuildRequest(
                    GET_FORWARDED_BY_PUBLIC_KEY, 
                    new RequestParameter
                    {
                        Name = "publicKey",
                        Value = publicKey
                    }
                );

            return Client.Execute<AccountMetaDataPair>(request).Data;
        }

        public AccountMetaData GetStatus(string address)
        {
            RestRequest request = Builder.BuildRequest(
                    ACCOUNT_STATUS_PATH,
                    new RequestParameter
                    {
                        Name = "address",
                        Value = address
                    }
                );

            return Client.Execute<AccountMetaData>(request).Data;
        }

        public DataArray<TransactionMetaDataPair> GetTransfersIncoming(string address)
        {
            RestRequest request = Builder.BuildRequest(
                    ACCOUNT_TRANSFERS_INCOMING_PATH,
                    new RequestParameter
                    {
                        Name = "address",
                        Value = address
                    }
                );

            return Client.Execute<DataArray<TransactionMetaDataPair>>(request).Data;
        }

        public DataArray<TransactionMetaDataPair> GetTransfersOutgoing(string address)
        {
            RestRequest request = Builder.BuildRequest(
                    ACCOUNT_TRANSFERS_OUTGOING_PATH,
                    new RequestParameter
                    {
                        Name = "address",
                        Value = address
                    }
                );

            return Client.Execute<DataArray<TransactionMetaDataPair>>(request).Data;
        }

        public DataArray<TransactionMetaDataPair> GetTransfersAll(string address)
        {
            RestRequest request = Builder.BuildRequest(
                    ACCOUNT_TRANSFERS_ALL_PATH,
                    new RequestParameter
                    {
                        Name = "address",
                        Value = address
                    }
                );

            return Client.Execute<DataArray<TransactionMetaDataPair>>(request).Data;
        }

        public DataArray<AccountImportanceViewModel> GetImportances(string address)
        {
            RestRequest request = Builder.BuildRequest(
                    ACCOUNT_IMPORTANCES_PATH,
                    new RequestParameter
                    {
                        Name = "address",
                        Value = address
                    }
                );

            return Client.Execute<DataArray<AccountImportanceViewModel>>(request).Data;
        }

        /// <summary>
        /// TODO: Fix using request parameters breaks the API since the name has to be specified by the user which isn't what we want.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="optionalParameters"></param>
        /// <returns></returns>
        public DataArray<Namespace> GetNamespaces(string address, params RequestParameter[] optionalParameters)
        {
            RequestParameter[] parameters = new RequestParameter[optionalParameters.Length + 1];

            parameters[0] = new RequestParameter
            {
                Name = "address",
                Value = address
            };

            optionalParameters.CopyTo(parameters, 1);

            RestRequest request = Builder.BuildRequest(
                    ACCOUNT_NAMESPACE_PAGE_PATH,
                    parameters
                );

            return Client.Execute<DataArray<Namespace>>(request).Data;
        }
    }
}
