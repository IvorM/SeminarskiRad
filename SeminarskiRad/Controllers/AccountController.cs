using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SeminarskiRad.Models;
using SeminarskiRad.Models.IdentityModels;
using SeminarskiRad.Services;

namespace SeminarskiRad.Controllers
{
    public class AccountController : Controller
    {
        private SeminarEmployeeManager _userManager;

        public AccountController()
        {
        }

        public AccountController(SeminarEmployeeManager userManager)
        {
            UserManager = userManager;
        }

        public SeminarEmployeeManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<SeminarEmployeeManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(SeminarEmployee user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                SeminarEmployee user;
                if (ModelState.IsValid)
                {
                    if (new EmailAddressAttribute().IsValid(model.Email))
                    {
                        user = UserManager.FindByEmail(model.Email);
                        user = await UserManager.FindAsync(user.UserName, model.Password);
                    }
                    else
                    {
                        user = null;
                    }


                    if (user != null)
                    {                      
                        await SignInAsync(user, false);
                        return Json(new { status = "success", message = "Uspješno prijavljeni" });
                    }
                    else
                    {
                        return Json(new { status = "error", message = "Porgrešno korisničko ime ili lozinka" });
                    }
                }


                return Json(new { status = "error", message = "Došlo je do pogreške, pokušaje ponovno" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Porgrešno korisničko ime ili lozinka" });

            }

        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new SeminarEmployee() { UserName = model.UserName, Email = model.Email };
                IdentityResult result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    return Json(new { status = "success", message = "Registriran" });
                }

                    return Json(new { status = "error", message = "Greška prilikom registracije" });
        }
            return Json(new { status = "error", message = "Greška prilikom registracije" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public async Task<JsonResult> CheckUserName(String userName)
        {
            var user = await UserManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Json(true);
            }
          
                return Json(false);       
        }

        public async Task<JsonResult> CheckEmail(String email)
        {
            if (new EmailAddressAttribute().IsValid(email))
            {
                var user = await UserManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Json(true);
                }
                    return Json(false);      
            }        
                return Json(true);
        }
    }
    }