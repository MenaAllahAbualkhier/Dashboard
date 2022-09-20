using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.BL.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "This Field Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Maile")]
        public string Email { get; set; }
    }
}
