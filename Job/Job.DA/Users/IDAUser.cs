using Job.DT.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DA.Users
{
    public interface IDAUser
    {
        UserDTO GetUser(UserRequestDTO userRequest);
        EmployerDTO GetEmployer(UserRequestDTO userRequest);
        bool SaveUser(UserDTO user);
        bool SaveEmployer(EmployerDTO employer);
        List<DegreeDTO> GetDegree();
        List<IndustryDTO> GetIndustry();
    }
}
