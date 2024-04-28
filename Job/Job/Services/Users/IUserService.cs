using Job.DT.Responses;
using Job.DT.Users;

namespace Job.Services.Users
{
    public interface IUserService
    {
        ResponseDTO<UserDTO> GetUser(UserRequestDTO user);
        ResponseDTO<EmployerDTO> GetEmployer(UserRequestDTO user);
        ResponseDTO<bool> SaveUser(UserDTO user);
        ResponseDTO<bool> SaveEmployer(EmployerDTO employer);
        ResponseDTO<List<IndustryDTO>> GetIndustry();
        ResponseDTO<List<DegreeDTO>> GetDegrees();
    }
}
