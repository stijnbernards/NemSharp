using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NemSharp.Request.Objects;
using RestSharp;

namespace NemSharp.Request.Objects
{
    public class Account : RequestBase
    {
        const string GENERATE_PATH = "/account/generate";

        public Account(RestClient client) : base(client) { }

        public KeyPairViewModel Generate()
        {
            RestRequest request = Builder.BuildRequest(GENERATE_PATH);

            Console.WriteLine(Client.Execute<KeyPairViewModel>(request).Content);

            return Client.Execute<KeyPairViewModel>(request).Data;
        }
    }
}
