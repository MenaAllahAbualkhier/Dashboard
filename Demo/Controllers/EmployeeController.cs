using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IDepartmentRepo Department;
        private readonly IMapper mapper;
        private readonly IEmployeeRepo Employee;
        private readonly ICityRepo City;
        private readonly IDistrictRepo distric;

        public EmployeeController(IDepartmentRepo Department, IMapper mapper , IEmployeeRepo Employee
            ,ICityRepo City,IDistrictRepo Distric)
        {
            this.Department = Department;
            this.mapper = mapper;
            this.Employee = Employee;
            this.City = City;
            distric = Distric;
        }
        public IActionResult Index(string? SearchValue)
        {
            if (SearchValue ==null)
            {
                var data = Employee.Get();
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(model);
            }
            else
            {
                var data = Employee.SearchByName(SearchValue);
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(Department.Get(),"Id","Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Employee>(obj);
                    Employee.Create(model);
                    return RedirectToAction("Index");
                }
                ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name");
                return View(obj);

            }
            catch
            {
                ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name");
                return View(obj);
            }

        }
        public IActionResult Details(int Id)
        {
            var data = Employee.GetById(Id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name",model.DepartmentId);
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var data = Employee.GetById(Id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name", model.DepartmentId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(EmployeeVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Employee>(obj);
                    Employee.Edit(model);
                    return RedirectToAction("Index");
                }
                ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name", obj.DepartmentId);
                return View(obj);
            }
            catch
            {
                ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name", obj.DepartmentId);
                return View(obj);
            }
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var data = Employee.GetById(Id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name", model.DepartmentId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeVM obj)
        {
            try
            {
                var model = mapper.Map<Employee>(obj);
                Employee.Delete(model);
                return RedirectToAction("index");
            }
            catch
            {
                ViewBag.DepartmentList = new SelectList(Department.Get(), "Id", "Name", obj.DepartmentId);
                return View(obj);
            }
        }
        [HttpPost]
        public JsonResult GetCityByCountryId(int CtryId)
        {
            var data = City.Get(a => a.CountryId == CtryId);
            var model = mapper.Map<IEnumerable<CityVM>>(data);
            return Json(model);
        }

        [HttpPost]
        public JsonResult GetDistricByCityId(int CtyId)
        {
            var data = distric.Get(a => a.CityId == CtyId);
            var model = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(model);
        }
        

    }
}
