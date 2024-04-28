using Job.DA.Offer;
using Job.DA.Users;
using Job.DT.Offer;
using Job.DT.Responses;
using Job.DT.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.BM.Offer
{
    public class BMOffer : IBMOffer
    {
        private readonly IDAOffer dAOffer;

        public BMOffer(IDAOffer dAOffer)
        {
            this.dAOffer = dAOffer;
        }
        public ResponseDTO<List<OfferDTO>> GetOffers()
        {
            ResponseDTO<List<OfferDTO>> responseDTO = new ResponseDTO<List<OfferDTO>>();
            responseDTO.Value = this.dAOffer.GetOffers();
            if (responseDTO.Value != null)
            {
                responseDTO.Messagge = ResourceBAOffer.GetSuccesful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBAOffer.GetUnSuccesful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<List<OfferApplyDTO>> GetOffersApply(OfferRequestDTO offer)
        {
            ResponseDTO<List<OfferApplyDTO>> responseDTO = new ResponseDTO<List<OfferApplyDTO>>();
            responseDTO.Value = this.dAOffer.GetOffersApply(offer);
            if (responseDTO.Value != null)
            {
                responseDTO.Messagge = ResourceBAOffer.GetSuccesful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBAOffer.GetUnSuccesful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<bool> SaveOffer(OfferDTO offer)
        {
            ResponseDTO<bool> responseDTO = new ResponseDTO<bool>();
            bool result = this.dAOffer.SaveOffer(offer);
            if (result)
            {
                responseDTO.Value = result;
                responseDTO.Messagge = ResourceBAOffer.SaveSuccessful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBAOffer.SaveUnSuccessful;
                responseDTO.Result = false;
            }
            return responseDTO;
        }

        public ResponseDTO<bool> SaveOfferApply(OfferRequestDTO offer)
        {
            ResponseDTO<bool> responseDTO = new ResponseDTO<bool>();
            bool result = this.dAOffer.SaveOfferApply(offer);
            if (result)
            {
                responseDTO.Value = result;
                responseDTO.Messagge = ResourceBAOffer.SaveSuccessful;
                responseDTO.Result = true;
            }
            else
            {
                responseDTO.Messagge = ResourceBAOffer.AlreadySaveOfferApply;
                responseDTO.Result = false;
            }
            return responseDTO;
        }
    }
}
