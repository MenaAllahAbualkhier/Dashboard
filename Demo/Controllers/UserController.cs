using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Extend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]

    public class UserController : Controller
    {
        #region Const
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IuserRepo userRepo;

        public UserController(IMapper mapper, UserManager<ApplicationUser> userManager ,IuserRepo userRepo)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.userRepo = userRepo;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var user = userManager.Users;
            var data = mapper.Map<IEnumerable<UserVM>>(user);
            return View(data);
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            var model = mapper.Map<UserVM>(user);
            return View(model);
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            var model = mapper.Map<UserVM>(user);
            return View(model);
        }
       
        [HttpPost]
        public async Task<IActionResult> Update(UserVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<ApplicationUser>(model);
                    var test = await userRepo.Update(data);
                    var result = await userManager.UpdateAsync(test);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(model);

                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }
        }
        #endregion


        #region Delete
        public async Task<IActionResult> Delete(string Id)
        {
            var data = await userManager.FindByIdAsync(Id);
            var model = mapper.Map<UserVM>(data);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UserVM model)
        {
            try
            {
                var data = await userManager.FindByIdAsync(model.Id);
                var result = await userManager.DeleteAsync(data);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);

                }
            }
            catch
            {
                return View(model);
            }
        }
        #endregion




    }
}
