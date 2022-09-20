using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.BL.Models
{
    public class UserVM
    {

        public string Id { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [MinLength(3, ErrorMessage = "Min Length Is :3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Maile")]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "enter 11 Number")]
        public virtual string PhoneNumber { get; set; }
    }
}
