using RestSharp.Deserializers;

namespace NemSharp.Request.Responses
{
    public class NemRequestResult
    {
        [DeserializeAs(Name = "type")]
        public int Type { get; set; }
        [DeserializeAs(Name = "code")]
        public int Code { get; set; }
        [DeserializeAs(Name = "message")]
        public string Message { get; set; }

        public NemRequestResult()
        {
            
        }

        public NemRequestResult(int type, int code, string message)
        {
            Type = type;
            Code = code;
            Message = message;
        }
    }
}
