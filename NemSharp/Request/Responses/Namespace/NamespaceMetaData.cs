using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Namespace
{
    public class NamespaceMetaData
    {
        [DeserializeAs(Name = "id")]
        public int ID { get; set; }
    }
}
