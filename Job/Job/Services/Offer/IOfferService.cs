using Job.DT.Offer;
using Job.DT.Responses;

namespace Job.Services.Offer
{
    public interface IOfferService
    {
        ResponseDTO<List<OfferDTO>> GetOffers();
        ResponseDTO<bool> SaveOffer(OfferDTO offer);
        ResponseDTO<bool> SaveOfferApply(OfferRequestDTO offer);
        ResponseDTO<List<OfferApplyDTO>> GetOffersApply(OfferRequestDTO offer);
    }
}
