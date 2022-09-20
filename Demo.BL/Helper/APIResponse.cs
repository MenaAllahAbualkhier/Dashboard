using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Helper
{
    public class APIResponse<Type>
    {
        public string Code { get; set; }
        public string State { get; set; }

        public string Message { get; set; }
        public Type Data { get; set; }
        public Type Error { get; set; }
    }
}
