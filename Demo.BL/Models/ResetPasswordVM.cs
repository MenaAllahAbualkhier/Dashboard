using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.BL.Models
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "This Field Is Required")]
        [MinLength(5, ErrorMessage = "Min Length Is :5")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [MinLength(5, ErrorMessage = "Min Length Is :5")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
