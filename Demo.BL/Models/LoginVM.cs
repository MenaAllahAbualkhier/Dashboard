using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demo.BL.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This Field Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Maile")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [MinLength(5, ErrorMessage = "Min Length Is :5")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
