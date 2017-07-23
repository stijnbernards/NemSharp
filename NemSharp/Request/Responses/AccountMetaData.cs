using System.Collections.Generic;
using RestSharp.Deserializers;

namespace NemSharp.Request.Responses
{
    public class AccountMetaData
    {
        [DeserializeAs(Name = "consignatoryOf")]
        public List<string> ConsignatoryOf { get; set; }
        [DeserializeAs(Name = "consignatories")]
        public List<string> Consignatories { get; set; }
        [DeserializeAs(Name = "status")]
        public string Status { get; set; }
        [DeserializeAs(Name = "remotestatus")]
        public string RemoteStatus { get; set; }
    }
}
