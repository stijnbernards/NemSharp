using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Transaction
{
    public class TransactionMetaDataPair
    {
        [DeserializeAs(Name = "meta")]
        public TransactionMetaData Meta { get; set; }
        [DeserializeAs(Name = "transaction")]
        public Transaction Transaction { get; set; }
    }
}
