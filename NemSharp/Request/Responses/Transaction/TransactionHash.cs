using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Transaction
{
    public class TransactionHash
    {
        [DeserializeAs(Name = "data")]
        public string Data { get; set; }
    }
}
