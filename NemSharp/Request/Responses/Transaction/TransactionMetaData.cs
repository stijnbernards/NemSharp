using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Transaction
{
    public class TransactionMetaData
    {
        [DeserializeAs(Name = "height")]
        public int Height { get; set; }
        [DeserializeAs(Name = "id")]
        public int ID { get; set; }
        [DeserializeAs(Name = "hash")]
        public TransactionHash Hash { get; set; }
    }
}
