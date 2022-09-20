using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]
    public class CVController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICvInformationRepo cvInformation;

        public CVController (IMapper mapper, ICvInformationRepo cvInformation)
        {
            this.mapper = mapper;
            this.cvInformation = cvInformation;
        }

        public IActionResult Index()
        {
            var data = cvInformation.Get();
            var model = mapper.Map <IEnumerable<CvInformationVM>>(data);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CvInformationVM model)
        {
            try
            {
                model.PhotoName = UploadFile.uploadFile(model.Photo, "/wwwroot/File/Image/");
                model.CvName = UploadFile.uploadFile(model.Photo, "/wwwroot/File/Doce/");
                var result = mapper.Map<CvInformation>(model);
                cvInformation.AddCv(result);

                return RedirectToAction("Index");
            }
            catch
            { 
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var data = cvInformation.GetById(id);
                UploadFile.DeleteFile(data.PhotoName, "/wwwroot/File/Image/");
                UploadFile.DeleteFile(data.CvName, "/wwwroot/File/Doce/");
                cvInformation.Delete(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
