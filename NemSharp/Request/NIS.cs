using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NemSharp.Request.Objects
{
    public class NIS : RequestBase
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
