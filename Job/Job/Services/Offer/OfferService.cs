using Job.DT.Offer;
using Job.DT.Responses;
using Job.DT.Users;
using Newtonsoft.Json;

namespace Job.Services.Offer
{
    public class OfferService : IOfferService
    {
        public ResponseDTO<List<OfferDTO>> GetOffers()
        {
            try
            {
                string result = ClientService.Get(Resource.GetOffers, string.Empty);
                return JsonConvert.DeserializeObject<ResponseDTO<List<OfferDTO>>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseDTO<bool> SaveOffer(OfferDTO offer)
        {
            try
            {
                string result = ClientService.Post(Resource.SaveOffer, JsonConvert.SerializeObject(offer));
                return JsonConvert.DeserializeObject<ResponseDTO<bool>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseDTO<bool> SaveOfferApply(OfferRequestDTO offer)
        {
            try
            {
                string result = ClientService.Post(Resource.SaveOfferApply, JsonConvert.SerializeObject(offer));
                return JsonConvert.DeserializeObject<ResponseDTO<bool>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ResponseDTO<List<OfferApplyDTO>> GetOffersApply( OfferRequestDTO offer)
        {
            try
            {
                string result = ClientService.Post(Resource.GetOffersApply, JsonConvert.SerializeObject(offer));
                return JsonConvert.DeserializeObject<ResponseDTO<List<OfferApplyDTO>>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
