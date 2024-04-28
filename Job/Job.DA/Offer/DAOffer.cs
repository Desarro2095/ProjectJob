using Dapper;
using Job.DA.Users;
using Job.DT.Offer;
using Job.DT.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DA.Offer
{
    public class DAOffer : IDAOffer
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public DAOffer(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = GetConnectionString();
        }

        public bool SaveOffer(OfferDTO offer)
        {
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    int result = connection.Execute(ResourceDAOffer.SaveOffer, offer);
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

        public List<OfferDTO> GetOffers()
        {
            try
            {
                List<OfferDTO> offers = new List<OfferDTO>();
                using (var connection = new SqlConnection(this.connectionString))
                {
                    using (var multi = connection.QueryMultiple(ResourceDAOffer.GetOffers))
                    {
                        offers = multi.Read<OfferDTO>().ToList();
                    }
                    if (offers != null && offers.Count > 0)
                    {
                        return offers;
                    }
                }
                return offers;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool SaveOfferApply(OfferRequestDTO offer)
        {
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    int result = connection.Execute(ResourceDAOffer.SaveOfferApply, offer);
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

        public List<OfferApplyDTO> GetOffersApply(OfferRequestDTO offer)
        {
            try
            {
                List<OfferApplyDTO> offers = new List<OfferApplyDTO>();
                using (var connection = new SqlConnection(this.connectionString))
                {
                    using (var multi = connection.QueryMultiple(string.Format(ResourceDAOffer.GetOfferApply, offer.EmployerId)))
                    {
                        offers = multi.Read<OfferApplyDTO>().ToList();
                    }
                    if (offers != null && offers.Count > 0)
                    {
                        return offers;
                    }
                }
                return offers;
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
