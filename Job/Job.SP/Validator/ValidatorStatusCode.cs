using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Job.SP.Validator
{
    public static class ValidatorStatusCode
    {
        public static HttpStatusCode GetStatusCode<T>(IEnumerable<T> obj)
        {
            if (!obj.Any())
            {
                return HttpStatusCode.NoContent;
            }
            return HttpStatusCode.OK;
        }

        public static HttpStatusCode GetStatusCode<T>(T obj)
        {
            if (obj is null)
            {
                return HttpStatusCode.NoContent;
            }
            return HttpStatusCode.OK;
        }
    }
}
