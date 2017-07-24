using System.Collections.Generic;
using RestSharp.Deserializers;

namespace NemSharp.Request.Responses
{
    public class DataArray<T>
    {
        [DeserializeAs(Name = "data")]
        public List<T> Data { get; set; }
    }
}
