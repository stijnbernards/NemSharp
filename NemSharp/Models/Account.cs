﻿using System;
using System.Security.Cryptography;
using Albireo.Base32;
using Chaos.NaCl;
using NemSharp.Request;
using NemSharp.Request.Responses;
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
                        Value = address,
                        Type = ParameterType.QueryString
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
                        Value = publicKey,
                        Type = ParameterType.QueryString
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
                        Value = address,
                        Type = ParameterType.QueryString
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
                        Value = publicKey,
                        Type = ParameterType.QueryString
                    }
                );

            return Client.Execute<AccountMetaDataPair>(request).Data;
        }
    }
}
