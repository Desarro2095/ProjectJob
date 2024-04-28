using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DT.Responses
{
    public class ResponseDTO<T>
    {
        public bool Result { get; set; }
        public string Messagge { get; set; }
        public T Value { get; set; }
    }
}
