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

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        #region Index
        public IActionResult Index()
        {
            var data = roleManager.Roles;
            return View(data);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await roleManager.CreateAsync(model);
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
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }


        #endregion

        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(IdentityRole model)
        {
            try
            {
               if(ModelState.IsValid)
                {
                    var user = await roleManager.FindByIdAsync(model.Id);
                    user.Name = model.Name;
                    var result = await roleManager.UpdateAsync(user);
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
                return View(model);

            }
            catch
            {
                return View(model);
            }
        }


        public async Task<IActionResult> AddOrRemoveUser(string RoleId)
        {
            ViewBag.roleid = RoleId;
            var Role = await roleManager.FindByIdAsync(RoleId);
            var model = new List<UserInRoleVM>();
            foreach(var user in userManager.Users)
            {
                var UserInRoleVM = new UserInRoleVM
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await userManager.IsInRoleAsync(user, Role.Name))
                {
                    UserInRoleVM.IsSelected = true;
                }
                else
                {
                    UserInRoleVM.IsSelected = false;
                }
                model.Add(UserInRoleVM);
            }
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUser(string RoleId, List<UserInRoleVM> model)
        {
            var role = await roleManager.FindByIdAsync(RoleId);
            for(int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                if(model[i].IsSelected&&!(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model[i].IsSelected&&(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

            }
            return RedirectToAction("Edit", new { Id = RoleId });
        }

        #endregion
    }
}
