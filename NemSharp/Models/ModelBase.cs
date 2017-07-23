using RestSharp;

namespace NemSharp.Models
{
    public class ModelBase
    {
        protected RestClient Client;

        public ModelBase(RestClient client)
        {
            Client = client;
        }
    }
}
