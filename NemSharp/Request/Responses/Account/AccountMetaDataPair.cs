﻿using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Account
{
    public class AccountMetaDataPair
    {
        [DeserializeAs(Name = "account")]
        public AccountInfo Account { get; set; }
        [DeserializeAs(Name = "meta")]
        public AccountMetaData MetaData { get; set; }
    }
}
