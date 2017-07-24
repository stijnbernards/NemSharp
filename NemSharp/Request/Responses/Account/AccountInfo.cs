using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Account
{
    public class AccountInfo
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; set; }
        [DeserializeAs(Name = "balance")]
        public int Balance { get; set; }
        [DeserializeAs(Name = "vestedBalance")]
        public int VestedBalance { get; set; }
        [DeserializeAs(Name = "importance")]
        public float Importance { get; set; }
        [DeserializeAs(Name = "publicKey")]
        public string PublicKey { get; set; }
        [DeserializeAs(Name = "label")]
        public string Label { get; set; }
    }
}
