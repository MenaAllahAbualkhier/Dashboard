using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProjectRepo project;
        private readonly DemoContext db;

        public ProjectController(IMapper mapper, IProjectRepo Project)
        {
            this.mapper = mapper;
            this.project = Project;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<project>(obj);
                    project.Create(model);
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch
            {
                return View(obj);
            }

        }
    }
}
