using Job.DT.Responses;
using Job.DT.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.BM.Users
{
    public interface IBMUser
    {
        ResponseDTO<UserDTO> GetUser(UserRequestDTO userRequest);
        ResponseDTO<EmployerDTO> GetEmployer(UserRequestDTO userRequest);
        ResponseDTO<bool> SaveUser(UserDTO user);
        ResponseDTO<bool> SaveEmployer(EmployerDTO employer);
        ResponseDTO<List<DegreeDTO>> GetDegree();
        ResponseDTO<List<IndustryDTO>> GetIndustry();
    }
}
