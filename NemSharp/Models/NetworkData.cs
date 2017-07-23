using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemSharp.Models
{
    public struct NetworkData
    {
        public string Name { get; }
        public int Prefix { get; }
        public int ID { get; }
        public char Char { get; }

        public NetworkData(
                string name,
                int prefix,
                int id, 
                char prefixChar
            )
        {
            Name = name;
            Prefix = prefix;
            ID = id;
            Char = prefixChar;
        }
    }
}