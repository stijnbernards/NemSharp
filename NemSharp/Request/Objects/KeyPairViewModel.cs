namespace NemSharp.Request.Objects
{
    public class KeyPairViewModel
    {
        public string PrivateKey;
        public string PublicKey;
        public string Address;

        public KeyPairViewModel() { }

        public KeyPairViewModel(string privateKey, string publicKey, string address)
        {
            PrivateKey = privateKey;
            PublicKey = publicKey;
            Address = address;
        }
    }
}
