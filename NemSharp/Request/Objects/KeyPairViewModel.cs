using RestSharp.Deserializers;

namespace NemSharp.Request.Objects
{
    public class KeyPairViewModel
    {
        [DeserializeAs(Name = "privatekey")]
        public string PrivateKey { get; set; }
        [DeserializeAs(Name = "publickey")]
        public string PublicKey { get; set; }
        [DeserializeAs(Name = "address")]
        public string Address { get; set; }

        public KeyPairViewModel() { }

        public KeyPairViewModel(string privateKey, string publicKey, string address)
        {
            PrivateKey = privateKey;
            PublicKey = publicKey;
            Address = address;
        }
    }
}
