using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Account
{
    public class AccountImportance
    {
        [DeserializeAs(Name = "isSet")]
        public int IsSet { get; set; }
        [DeserializeAs(Name = "score")]
        public float Score { get; set; }
        [DeserializeAs(Name = "ev")]
        public float EV { get; set; }
        [DeserializeAs(Name = "height")]
        public int Height { get; set; }
    }
}
