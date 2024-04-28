using Job.DA.Users;
using Job.DT.Responses;
using Job.DT.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.BM.Users
{
    public class BMUser : IBMUser
    {
        private readonly IDAUser dAUser;

        public BMUser(IDAUser dAUser)
        {
            this.dAUser = dAUser;
        }

        public ResponseDTO<UserDTO> GetUser(UserRequestDTO userRequest)
        {
            ResponseDTO<UserDTO> responseDTO = new ResponseDTO<UserDTO>();
            responseDTO.Value = this.dAUser.GetUser(userRequest);
            if (responseDTO.Value != null)
            {
                responseDTO.Messagge = ResourceBMUser.GetSuccesful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBMUser.GetUnSuccesful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<EmployerDTO> GetEmployer(UserRequestDTO userRequest)
        {
            ResponseDTO<EmployerDTO> responseDTO = new ResponseDTO<EmployerDTO>();
            responseDTO.Value = this.dAUser.GetEmployer(userRequest);
            if (responseDTO.Value != null)
            {
                responseDTO.Messagge = ResourceBMUser.GetSuccesful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBMUser.GetUnSuccesful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<bool> SaveUser(UserDTO user)
        {
            ResponseDTO<bool> responseDTO = new ResponseDTO<bool>();
            bool result = this.dAUser.SaveUser(user);
            if (result)
            {
                responseDTO.Value = result;
                responseDTO.Messagge = ResourceBMUser.SaveSuccessful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBMUser.SaveUnSuccessful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<bool> SaveEmployer(EmployerDTO employer)
        {
            ResponseDTO<bool> responseDTO = new ResponseDTO<bool>();
            bool result = this.dAUser.SaveEmployer(employer);
            if (result)
            {
                responseDTO.Value = result;
                responseDTO.Messagge = ResourceBMUser.SaveSuccessful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBMUser.SaveUnSuccessful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<List<DegreeDTO>> GetDegree()
        {
            ResponseDTO<List<DegreeDTO>> responseDTO = new ResponseDTO<List<DegreeDTO>>();
            responseDTO.Value = this.dAUser.GetDegree();
            if (responseDTO.Value != null)
            {
                responseDTO.Messagge = ResourceBMUser.GetSuccesful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBMUser.GetUnSuccesful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<List<IndustryDTO>> GetIndustry()
        {
            ResponseDTO<List<IndustryDTO>> responseDTO = new ResponseDTO<List<IndustryDTO>>();
            responseDTO.Value = this.dAUser.GetIndustry();
            if (responseDTO.Value != null)
            {
                responseDTO.Messagge = ResourceBMUser.GetSuccesful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBMUser.GetUnSuccesful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }
    }
}
