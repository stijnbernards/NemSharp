using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
