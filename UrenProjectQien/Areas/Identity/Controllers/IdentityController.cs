using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace UrenProjectQien.Areas.Identity.Controllers
{
    public class IdentityController : Controller
    {
        public async Task <IActionResult> Index()
        {
            try
            {
                ViewBag.Message = "User already registered";

                AccountIdentity user = await userManager.FindByNameAsync("Jason");
                if (user == null)
                {
                    user.IBAN = "12345123";
                    user.FirstName = "jason";
                    user.LastName = "pengel";
                    user.City = "Amsterdam";

                    IdentityResult result = await userManager.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        private UserManager<AccountIdentity> userManager { get; }

        private SignInManager<AccountIdentity> signInManager { get; }
        public IdentityController(UserManager<AccountIdentity> usermanager,SignInManager<AccountIdentity> signinmanager)
        {
            userManager = usermanager;
            signInManager = signinmanager;
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";

                AccountIdentity user = await userManager.FindByNameAsync("Jason");
                if (user == null)
                {
                    user.IBAN = "12345123";
                    user.FirstName = "jason";
                    user.LastName = "pengel";
                    user.City = "Amsterdam";

                    IdentityResult result = await userManager.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }
    }
}