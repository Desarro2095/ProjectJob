using Job.DT.Offer;
using Job.DT.Responses;
using Job.DT.Users;
using Job.Models;
using Job.Services;
using Job.Services.Offer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Job.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOfferService offerService;

        public HomeController(ILogger<HomeController> logger, IOfferService offerService)
        {
            this.offerService = offerService;
            _logger = logger;
        }

        public IActionResult Index(string message = null)
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            string nameUser = string.Empty;
            string role = string.Empty;

            if (claimsUser.Identity.IsAuthenticated)
            {
                nameUser = claimsUser.Claims.Where(x => x.Type == ClaimTypes.Name)
                    .Select(x => x.Value).SingleOrDefault();
                role = claimsUser.Claims.Where(x => x.Type == ClaimTypes.Role)
                    .Select(x => x.Value).SingleOrDefault();
                if (role == "Person")
                {
                    ViewBag.Offer = offerService.GetOffers().Value;
                    ViewBag.User = JsonConvert.DeserializeObject<UserDTO>(claimsUser.Claims.Where(x => x.Type == ClaimTypes.UserData)
                    .Select(x => x.Value).SingleOrDefault());
                }
                else
                {
                    ViewBag.User = JsonConvert.DeserializeObject<EmployerDTO>(claimsUser.Claims.Where(x => x.Type == ClaimTypes.UserData)
                    .Select(x => x.Value).SingleOrDefault());
                }
            }

            ViewBag.Role = role;
            ViewData["Message"] = message;
            ViewData["nameUser"] = nameUser;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","LogIn");
        }

        [HttpPost]
        public IActionResult SaveOffer(OfferDTO offerDTO)
        {
            ResponseDTO<bool> result = offerService.SaveOffer(offerDTO);
            if (!result.Result)
            {
                return RedirectToAction("Index", "Home", new { message = result.Messagge });
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SaveOfferApply(int userId, int offerId)
        {
            ResponseDTO<bool> result = offerService.SaveOfferApply(new OfferRequestDTO { OfferId = offerId, UserId = userId});
            if (!result.Result)
            {
                return RedirectToAction("Index", "Home", new { message = result.Messagge });
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
