using Demo.DAL.Extend;
using Demo.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IStringLocalizer<SharedResource> localizer,UserManager<ApplicationUser>userManager )
        {
            this.localizer = localizer;
            this.userManager = userManager;
        }
        public async Task< IActionResult> Index()
        {
            ViewBag.mes = localizer["DASHBOARD"];
            var userinfo = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.test = userinfo.UserName;
            return View();
        }
    }
}
