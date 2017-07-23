using System.Collections.Generic;

namespace NemSharp.Models
{
    public class Wallet
    {
        public string PrivateKey;
        public string Name;
        public Dictionary<int, Account> Accounts = new Dictionary<int, Account>();
    }
}
