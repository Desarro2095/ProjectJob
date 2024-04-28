using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Job.Services.Users;
using Job.DT.Users;
using Job.SP.Validator;
using Job.SP.Security;
using Job.DT.Responses;
using Newtonsoft.Json;

namespace Job.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult SingIn()
        {
            ViewBag.Degree = userService.GetDegrees().Value;
            return View();
        }

        public IActionResult SingInEmployer()
        {
            ViewBag.Industry = userService.GetIndustry().Value;
            return View();
        }

        [HttpPost]
        public IActionResult SingIn(UserDTO user)
        {
            user.UserPassword = Encrypt.EncryptPassword(user.UserPassword);
            ResponseDTO<bool> result = userService.SaveUser(user);
            if (result.Result && result.Value)
            {
                return RedirectToAction("LogIn","Login");
            }
            else
            {
                ViewData["Message"] = result.Messagge;
            }
            return View();
        }

        [HttpPost]
        public IActionResult SingInEmployer(EmployerDTO employerDTO)
        {
            employerDTO.UserPassword = Encrypt.EncryptPassword(employerDTO.UserPassword);
            ResponseDTO<bool> result = userService.SaveEmployer(employerDTO);
            if (result.Result && result.Value)
            {
                return RedirectToAction("LogInEmployer", "Login");
            }
            else
            {
                ViewData["Message"] = result.Messagge;
            }
            return View();
        }

        public IActionResult LogIn()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            if (claimsUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult LogInEmployer()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            if (claimsUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(UserRequestDTO userRequest)
        {
            userRequest.Password = Encrypt.EncryptPassword(userRequest.Password);
            ResponseDTO<UserDTO> result = userService.GetUser(userRequest);
            if (!result.Result)
            {
                ViewData["Message"] = result.Messagge;
                return View();
            }
            else
            {
                List<Claim> claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, result.Value.NameUser),
                    new Claim(ClaimTypes.Role, "Person"),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(result.Value))
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                );
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult LogInEmployer(UserRequestDTO userRequest)
        {
            userRequest.Password = Encrypt.EncryptPassword(userRequest.Password);
            ResponseDTO<EmployerDTO> result = userService.GetEmployer(userRequest);
            if (!result.Result)
            {
                ViewData["Message"] = result.Messagge;
                return View();
            }
            else
            {
                List<Claim> claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, result.Value.NameUser),
                    new Claim(ClaimTypes.Role, "Business"),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(result.Value))
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                );
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
