using System;
using NemSharp.Request.Objects;
using RestSharp;

namespace NemSharp
{
    public class NemClient
    {
        public NIS NIS => _nis ?? (_nis = new NIS(_client));
        public Account Account => _account ?? (_account = new Account(_client));

        private readonly RestClient _client;
        private NIS _nis;
        private Account _account;

        public NemClient(string url)
        {
            _client = new RestClient(url);
        }
    }
}