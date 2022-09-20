using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Models;
using Demo.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper mapper;

        #region Const
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(IMapper mapper, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #endregion


        #region Sign Up
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = mapper.Map<ApplicationUser>(model);
                    var result = await userManager.CreateAsync(user,model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }
                    return View(model);
                }
                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        TempData["id"] = user.Id;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalied Email Or Password");
                        return View(model);
                    }
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        #endregion


        #region ForgotPassword
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> ForgotPassword(ForgetPasswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                        MailSender.SendMaile(new EmaliVM { Title = "Password Reset", Massage = passwordResetLink, Mail = model.Email });

                        //logger.Log(LogLevel.Warning, passwordResetLink);

                        return RedirectToAction("ForgotPasswordConfirm");
                    }

                    return View(model);
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult ForgotPasswordConfirm()
        {
            return View();
        }
        #endregion


        #region Reset Password
        [HttpGet]
        public IActionResult ResetPassword(string Email,string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult>ResetPassword(ResetPasswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ConfirmResetPassword");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }

                    return View(model);
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }
        #endregion


        #region Sign Out
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion

    }
}
