using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DT.Users
{
    public abstract class UserPersonDTO
    {
        public string NameUser { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserPassword { get; set; }
    }
}
