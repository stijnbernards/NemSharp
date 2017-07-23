using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NemSharp.Models;

namespace NemSharp.Data
{
    public static class Networks
    {
        public static NetworkData MainNet = new NetworkData(
                "Mainnet",
                68,
                104,
                'N'
            );

        public static NetworkData TestNet = new NetworkData(
                "Testnet",
                98,
                -104,
                'T'
            );

        public static NetworkData Mijin = new NetworkData(
                "Mijin",
                60,
                96,
                'M'
            );
    }
}