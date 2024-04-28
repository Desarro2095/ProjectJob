using Dapper;
using Job.DT.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DA.Users
{
    public class DAUser : IDAUser
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public DAUser(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = GetConnectionString();
        }

        public UserDTO GetUser(UserRequestDTO userRequest)
        {
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    UserDTO result = connection.QueryFirstOrDefault<UserDTO>(
                                                string.Format(ResourceDAUser.GetUser, userRequest.User, userRequest.User, userRequest.Password));
                    if (result != null)
                    {
                        return result;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EmployerDTO GetEmployer(UserRequestDTO userRequest)
        {
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    EmployerDTO result = connection.QueryFirstOrDefault<EmployerDTO>(
                                                string.Format(ResourceDAUser.GetEmployer, userRequest.User, userRequest.User, userRequest.Password));
                    if (result != null)
                    {
                        return result;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SaveUser(UserDTO user)
        {
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    int result = connection.Execute(ResourceDAUser.SaveUser, user);
                    if (result > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool SaveEmployer(EmployerDTO employer)
        {
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    int result = connection.Execute(ResourceDAUser.SaveEmployer, employer);
                    if (result > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DegreeDTO> GetDegree()
        {
            try
            {
                List<DegreeDTO> degrees = new List<DegreeDTO>();
                using (var connection = new SqlConnection(this.connectionString))
                {
                    using (var multi = connection.QueryMultiple(ResourceDAUser.GetDegree))
                    {
                        degrees = multi.Read<DegreeDTO>().ToList();
                    }
                    if (degrees != null && degrees.Count > 0)
                    {
                        return degrees;
                    }
                }
                return degrees;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public List<IndustryDTO> GetIndustry()
        {
            try
            {
                List<IndustryDTO> industries = new List<IndustryDTO>();
                using (var connection = new SqlConnection(this.connectionString))
                {
                    using (var multi = connection.QueryMultiple(ResourceDAUser.GetIndustry))
                    {
                        industries = multi.Read<IndustryDTO>().ToList();
                    }
                    if (industries != null && industries.Count > 0)
                    {
                        return industries;
                    }
                }
                return industries;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("JobConnection");
        }
    }
}
