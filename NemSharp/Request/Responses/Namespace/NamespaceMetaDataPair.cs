using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Namespace
{
    public class NamespaceMetaDataPair
    {
        [DeserializeAs(Name = "meta")]
        public NamespaceMetaData MetaData { get; set; }
        [DeserializeAs(Name = "namespace")]
        public Namespace Namespace { get; set; }
    }
}
