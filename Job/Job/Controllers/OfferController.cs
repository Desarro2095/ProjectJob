using Job.DT.Offer;
using Job.DT.Responses;
using Job.Services.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Job.Controllers
{
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }
        public IActionResult ViewApplies(int employerId)
        {
            ResponseDTO<List<OfferApplyDTO>> result = offerService.GetOffersApply(new OfferRequestDTO { EmployerId = employerId });
            ViewBag.OfferApply = result.Value;
            return View();
        }
    }
}
