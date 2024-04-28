using Job.DT.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DA.Offer
{
    public interface IDAOffer
    {
        bool SaveOffer(OfferDTO offer);
        List<OfferDTO> GetOffers();
        bool SaveOfferApply(OfferRequestDTO offer);
        List<OfferApplyDTO> GetOffersApply(OfferRequestDTO offer);
    }
}
