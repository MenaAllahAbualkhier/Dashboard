using Demo.DAL.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IuserRepo
    {
         Task<ApplicationUser> Update(ApplicationUser model);
    }
}
