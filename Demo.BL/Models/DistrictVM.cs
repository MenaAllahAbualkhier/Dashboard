using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.DAL.Entity;

namespace Demo.BL.Models
{
    public class DistrictVM
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "File Is Required")]
        public string Name { get; set; }

        public int CtiyId { get; set; }
        public City City { get; set; }
    }
}
