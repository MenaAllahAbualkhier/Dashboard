using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime CreationDate { get; set; }
        public int? DistrictId { get; set; }
        public District District { get; set; }


    }
}