using RestSharp;

namespace NemSharp.Request
{
    public class RequestParameter
    {
        public ParameterType Type { get; set; } = ParameterType.QueryString;
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
