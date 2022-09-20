using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepatrmentController : ControllerBase
    {
        private readonly IDepartmentRepo department;
        private readonly IMapper mapper;

        public DepatrmentController(IDepartmentRepo Department , IMapper mapper)
        {
            department = Department;
            this.mapper = mapper;
        }
        #region Get Department
        [HttpGet]
        [Route("~/API/GetDepartment")]
        public IActionResult GetDepartment()
        {
            try
            {
                var data = department.Get();
                var model = mapper.Map<IEnumerable<DepartmentVM>>(data);
                return Ok(new APIResponse<IEnumerable<DepartmentVM>>()
                {
                    Code = "200",
                    State = "Ok",
                    Message = "Data retrieved successfully",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return NotFound(new APIResponse<string>()
                {
                    Code = "404",
                    State = "NotFound",
                    Message = "Data retrieved failed",
                    Error = ex.Message

                });
            }
        }
        #endregion

        #region Get Department By Id
        [HttpGet]
        [Route("~/API/GetDepartmentById/{Id}")]
        public IActionResult GetDepartmentById (int Id)
        {
            try
            {
                var data = department.GetById(Id);
                var model = mapper.Map<DepartmentVM>(data);
                return Ok(new APIResponse<DepartmentVM>
                {
                    Code = "200",
                    State = "Ok",
                    Message = "Data retrieved successfully",
                    Data = model

                });
            }
            catch(Exception ex)
            {
                return NotFound(new APIResponse<string> { 
                    Code="404",
                    State= "NotFound",
                    Message= "Data retrieved failed",
                    Error=ex.Message
                });
            }
        }
        #endregion

        #region Create Department
        [HttpPost]
        [Route("~/API/CreateDepartment")]
        public  IActionResult CreateDepartment(DepartmentVM model)
        {
            try
            {
                
                    var data = mapper.Map<Department>(model);
                    var result = department.CreateWithReturn(data);
                    return Ok(new APIResponse<Department>
                    {
                        Code = "200",
                        State = "Ok",
                        Message = "Create Department successfully",
                        Data = result
                    });
            }
            catch(Exception ex) 
            {
                return NotFound(new APIResponse<string> { 
                    Code="200",
                    State="NotFound",
                    Message="Create Department Failed",
                    Error=ex.Message
                });
            }
             
        }
        #endregion

        #region UpdateDepartment
        [HttpPut]
        [Route("~/API/UpdateDepartment")]
        public IActionResult UpdateDepartment(DepartmentVM obj)
        {
            try
            {
                var model = mapper.Map<Department>(obj);
                var result = department.EditWithReturn(model);
                return Ok(new APIResponse<Department>() { 
                      Code="200",
                      State="Ok",
                      Message= "Update Department successfully ",
                      Data=result
                });
            }
            catch(Exception ex)
            {
                return NotFound(new APIResponse<string> { 
                    Code="404",
                    State= "Not Found",
                    Message= "Update Department Failed",
                    Error=ex.Message
                });
            }
        }

        #endregion

        #region Delete Department
        [HttpDelete]
        [Route("~/API/DeleteDepartment")]
        public IActionResult DeleteDepartment (DepartmentVM model)
        {
            try
            {
                var data = mapper.Map<Department>(model);
                department.Delete(data);
                return Ok(new APIResponse<DepartmentVM> { 
                    Code="200",
                    State="Ok",
                    Message= "Delete Department successfully",
                    Data=model
                });
            }
            catch(Exception ex)
            {
                return NotFound(new APIResponse<string> { 
                    Code="404",
                    State= "NotFound",
                    Message= "Delete Department Failed",
                    Error=ex.Message

                });
            }

        }

        #endregion


    }
}
