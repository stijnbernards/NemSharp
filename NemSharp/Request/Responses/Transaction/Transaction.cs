using System;
using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Transaction
{
    public class Transaction
    {
        [DeserializeAs(Name = "timestamp")]
        public DateTime timestamp { get; set; }
        [DeserializeAs(Name = "amount")]
        public int Amount { get; set; }
        [DeserializeAs(Name = "signature")]
        public string Signature { get; set; }
        [DeserializeAs(Name = "fee")]
        public int Fee { get; set; }
        [DeserializeAs(Name = "recipient")]
        public string Recipient { get; set; }
        [DeserializeAs(Name = "type")]
        public int Type { get; set; }
        [DeserializeAs(Name = "deadline")]
        public DateTime Deadline { get; set; }
        [DeserializeAs(Name = "message")]
        public TransactionMessage Message { get; set; }
        [DeserializeAs(Name = "version")]
        public int Version { get; set; }
        [DeserializeAs(Name = "signer")]
        public string Signer { get; set; }
    }
}
