using Demo.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Demo.BL.Helper;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EmaliVM model)
        {
            try
            {
                model.Mail = "mnt33958@gmail.com";
                ViewBag.mes = MailSender.SendMaile(model);
                return View();
            }
            catch{
                model.Mail = "mnt33958@gmail.com";
                ViewBag.mes = MailSender.SendMaile(model);
                return View();
            }
        }
    }
}
