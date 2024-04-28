using Job.BM.Users;
using Job.DT.Responses;
using Job.DT.Users;
using Job.SP.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Users.WS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IBMUser bMUser;

        public UserController(IBMUser bMUser)
        {
            this.bMUser = bMUser;
        }

        [HttpGet("GetUser")]
        public ActionResult<ResponseDTO<UserDTO>> GetUser(UserRequestDTO userRequest)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<UserDTO> result = this.bMUser.GetUser(userRequest);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("GetEmployer")]
        public ActionResult<ResponseDTO<EmployerDTO>> GetEmployer(UserRequestDTO userRequest)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<EmployerDTO> result = this.bMUser.GetEmployer(userRequest);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("SaveUser")]
        public ActionResult<ResponseDTO<bool>> SaveUser(UserDTO user)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<bool> result = this.bMUser.SaveUser(user);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("SaveEmployer")]
        public ActionResult<ResponseDTO<bool>> SaveEmployer(EmployerDTO employer)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<bool> result = this.bMUser.SaveEmployer(employer);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("GetDegree")]
        public ActionResult<ResponseDTO<List<DegreeDTO>>> GetDegree()
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<List<DegreeDTO>> result = this.bMUser.GetDegree();
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("GetIndustry")]
        public ActionResult<ResponseDTO<List<IndustryDTO>>> GetIndustry()
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<List<IndustryDTO>> result = this.bMUser.GetIndustry();
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }
    }
}
