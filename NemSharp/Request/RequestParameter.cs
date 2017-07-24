using RestSharp;

namespace NemSharp.Request
{
    public struct RequestParameter
    {
        public ParameterType Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
