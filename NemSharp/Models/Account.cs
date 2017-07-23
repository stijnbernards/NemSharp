using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;
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
        const string GENERATE_PATH = "/account/generate";

        public Account(RestClient client) : base(client)
        {
            
        }

        public KeyPairViewModel GenerateFromNode()
        {
            RestRequest request = Builder.BuildRequest(GENERATE_PATH);

            Console.WriteLine(Client.Execute<KeyPairViewModel>(request).Content);

            return Client.Execute<KeyPairViewModel>(request).Data;
        }

        public KeyPairViewModel GenerateLocal(byte networkPrefix)
        {
            byte[] privateKey = new byte[32];

            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(privateKey);
            }

            Array.Reverse(privateKey);
            byte[] publicKey = Ed25519.PublicKeyFromSeed(privateKey);
            Array.Reverse(privateKey);

            string address = PublicKeyToAddress(publicKey, networkPrefix);

            return new KeyPairViewModel(Encoding.UTF8.GetString(privateKey), Encoding.UTF8.GetString(publicKey), address);
        }

        public string PublicKeyToAddress(byte[] publicKey, byte networkPrefix)
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
                    string.Concat(networkPrefix == 0x68 ? 68 : 98, 
                    CryptoBytes.ToHexStringLower(bytesSecond))
                );

            byte[] bytesFourth  = new byte[32];

            shaDigest.BlockUpdate(bytesThird, 0, 21);
            shaDigest.DoFinal(bytesFourth, 0);

            byte[] bytesFifth = new byte[4];
            Array.Copy(bytesFourth, 0, bytesFifth, 0, 4);

            byte[] bytesSixth = new byte[25];
            Array.Copy(bytesThird, 0, bytesSixth, 0, 21);
            Array.Copy(bytesFifth, 0, bytesSixth, 21, 4);

            return Base32.Encode(bytesSixth).ToUpper();
        }
    }
}
