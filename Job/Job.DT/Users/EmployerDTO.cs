using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DT.Users
{
    public class EmployerDTO : UserPersonDTO
    {
        public int EmployerId { get; set; }
        public int CurrentEmployee { get; set; }
        public int IndustryId { get; set; }
    }
}
