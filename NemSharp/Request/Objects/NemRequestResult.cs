using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemSharp.Request.Objects
{
    public class NemRequestResult
    {
        public int Type;
        public int Code;
        public string Message;

        public NemRequestResult()
        {
            
        }

        public NemRequestResult(int type, int code, string message)
        {
            Type = type;
            Code = code;
            Message = message;
        }
    }
}
