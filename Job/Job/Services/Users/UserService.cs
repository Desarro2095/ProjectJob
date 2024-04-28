using Job.DT.Responses;
using Job.DT.Users;
using Newtonsoft.Json;
using System.Text.Json;

namespace Job.Services.Users
{
    public class UserService : IUserService
    {
        public ResponseDTO<UserDTO> GetUser(UserRequestDTO user)
        {
			try
			{
				string result = ClientService.Get(Resource.GetUser, JsonConvert.SerializeObject(user));
				return JsonConvert.DeserializeObject<ResponseDTO<UserDTO>>(result);
            }
			catch (Exception)
			{
				throw;
			}
        }

        public ResponseDTO<EmployerDTO> GetEmployer(UserRequestDTO user)
        {
            try
            {
                string result = ClientService.Get(Resource.GetEmployer, JsonConvert.SerializeObject(user));
                return JsonConvert.DeserializeObject<ResponseDTO<EmployerDTO>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseDTO<bool> SaveUser(UserDTO user)
        {
			try
			{
                string result = ClientService.Post(Resource.SaveUser, JsonConvert.SerializeObject(user));
                return JsonConvert.DeserializeObject<ResponseDTO<bool>>(result);
            }
			catch (Exception)
			{
				throw;
			}
        }

        public ResponseDTO<bool> SaveEmployer(EmployerDTO employer)
        {
            try
            {
                string result = ClientService.Post(Resource.SaveEmployer, JsonConvert.SerializeObject(employer));
                return JsonConvert.DeserializeObject<ResponseDTO<bool>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseDTO<List<IndustryDTO>> GetIndustry()
        {
            try
            {
                string result = ClientService.Get(Resource.GetIndustry, string.Empty);
                return JsonConvert.DeserializeObject<ResponseDTO<List<IndustryDTO>>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseDTO<List<DegreeDTO>> GetDegrees()
        {
            try
            {
                string result = ClientService.Get(Resource.GetDegree, string.Empty);
                return JsonConvert.DeserializeObject<ResponseDTO<List<DegreeDTO>>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
