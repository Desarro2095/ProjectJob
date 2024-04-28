using Job.DT.Offer;
using Job.DT.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.BM.Offer
{
    public interface IBMOffer
    {
        ResponseDTO<bool> SaveOffer(OfferDTO offer);
        ResponseDTO<List<OfferDTO>> GetOffers();
        ResponseDTO<bool> SaveOfferApply(OfferRequestDTO offer);
        ResponseDTO<List<OfferApplyDTO>> GetOffersApply(OfferRequestDTO offer);
    }
}
