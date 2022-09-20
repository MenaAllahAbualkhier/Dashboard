using Demo.BL.Interface;
using Demo.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class UserRepo:IuserRepo
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepo(UserManager<ApplicationUser> userManager )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<ApplicationUser> Update(ApplicationUser model)
        {
           
                var data = await userManager.FindByIdAsync(model.Id);
                data.UserName = model.UserName;
                data.PhoneNumber = model.PhoneNumber;
                data.Email = model.Email;
                return data;
            
        }

    
    }
}
