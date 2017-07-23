using NemSharp.Request;
using NemSharp.Request.Responses;
using RestSharp;

namespace NemSharp.Models
{
    public class NIS : ModelBase
    {
        const string HEARTBEAT_PATH = "/heartbeat";
        private const string STATUS_PATH = "/status";

        public NIS(RestClient client) : base(client) { }

        public NemRequestResult HeartBeat()
        {
            RestRequest request = Builder.BuildRequest(HEARTBEAT_PATH);

            return Client.Execute<NemRequestResult>(request).Data;
        }

        public NemRequestResult Status()
        {
            RestRequest request = Builder.BuildRequest(STATUS_PATH);

            return Client.Execute<NemRequestResult>(request).Data;
        }
    }
}
