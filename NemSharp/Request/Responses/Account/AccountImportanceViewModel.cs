using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Account
{
    public class AccountImportanceViewModel
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; set; }
        [DeserializeAs(Name = "importance")]
        public AccountImportance Importance { get; set; }
    }
}
