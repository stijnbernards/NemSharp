using RestSharp;

namespace NemSharp.Request.Objects
{
    public class RequestBase
    {
        protected RestClient Client;

        public RequestBase(RestClient client)
        {
            Client = client;
        }
    }
}
