using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.BL.Repository;
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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo Department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRepo Department,IMapper mapper)
        {
            this.Department = Department;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = Department.Get();
            var model = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DepartmentVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Department>(obj);
                    Department.Create(model);
                    return RedirectToAction("Index");
                }
                return View(obj);

            }
            catch
            {
                return View(obj);
            }
            
        }
        public IActionResult Details(int Id)
        {
            var data = Department.GetById(Id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var data = Department.GetById(Id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(DepartmentVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Department>(obj);
                    Department.Edit(model);
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch
            {
                return View(obj);
            }
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var data = Department.GetById(Id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentVM obj)
        {
            try
            {
                var model = mapper.Map<Department>(obj);
                Department.Delete(model);
                return RedirectToAction("index");
            }
            catch
            {
                return View(obj);
            }
        }




    }
}
