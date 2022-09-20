using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.BL.Models
{
    public class CountryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Filed Is Required")]
        public string Name { get; set; }
    }
}
