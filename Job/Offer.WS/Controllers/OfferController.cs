using Job.BM.Offer;
using Job.DT.Offer;
using Job.DT.Responses;
using Job.SP.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Offer.WS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IBMOffer bMOffer;

        public OfferController(IBMOffer bMOffer)
        {
            this.bMOffer = bMOffer;
        }

        [HttpGet("GetOffers")]
        public ActionResult<ResponseDTO<List<OfferDTO>>> GetOffers()
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<List<OfferDTO>> result = this.bMOffer.GetOffers();
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("SaveOffer")]
        public ActionResult<ResponseDTO<bool>> SaveOffer(OfferDTO offer)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<bool> result = this.bMOffer.SaveOffer(offer);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("SaveOfferApply")]
        public ActionResult<ResponseDTO<bool>> SaveOfferApply(OfferRequestDTO offer)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<bool> result = this.bMOffer.SaveOfferApply(offer);
                status = ValidatorStatusCode.GetStatusCode(result);
                return StatusCode((int)status, result);
            }
            catch (Exception)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost("GetOffersApply")]
        public ActionResult<ResponseDTO<List<OfferApplyDTO>>> GetOffersApply(OfferRequestDTO offer)
        {
            try
            {
                HttpStatusCode status = HttpStatusCode.OK;
                ResponseDTO<List<OfferApplyDTO>> result = this.bMOffer.GetOffersApply(offer);
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
