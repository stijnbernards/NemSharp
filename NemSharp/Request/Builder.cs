using System.Collections.Generic;
using RestSharp;

namespace NemSharp.Request
{
    sealed class Builder
    {
        public static RestRequest BuildRequest(string path)
        {
            RestRequest request = new RestRequest(path);

            return request;
        }

        public static RestRequest BuildRequest(string path, List<RequestParameter> requestParameters)
        {
            return BuildRequest(path, requestParameters.ToArray());
        }

        public static RestRequest BuildRequest(string path, RequestParameter[] requestParameters)
        {
            RestRequest restRequest = new RestRequest(path);

            foreach (RequestParameter requestParameter in requestParameters)
            {
                restRequest.AddParameter(requestParameter.Name, requestParameter.Value, requestParameter.Type);
            }

            return restRequest;
        }

        public static RestRequest BuildRequest(string path, RequestParameter requestParameter)
        {
            RestRequest restRequest = new RestRequest(path);
            restRequest.AddParameter(requestParameter.Name, requestParameter.Value, requestParameter.Type);

            return restRequest;
        }
    }
}
