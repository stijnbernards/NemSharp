using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Transaction
{
    public class TransactionMessage
    {
        [DeserializeAs(Name = "payload")]
        public string Payload { get; set; }
        [DeserializeAs(Name = "type")]
        public int Type { get; set; }
    }
}
