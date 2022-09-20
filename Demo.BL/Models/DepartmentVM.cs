using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.BL.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="Max Length = 50")]
        [MinLength(2,ErrorMessage ="Min Lenght = 2")]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
