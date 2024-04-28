using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DT.Users
{
    public class UserDTO : UserPersonDTO
    {
        public int UserId { get; set; }
        public int DegreeId { get; set; }
    }
}
