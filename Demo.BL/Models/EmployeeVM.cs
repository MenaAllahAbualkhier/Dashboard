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
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            CreationDate = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max Length = 50")]
        [MinLength(3,ErrorMessage = "Min Lenght = 2")]
        public string Name { get; set; }

        [Required]
        [Range(2000,10000,ErrorMessage ="Salary Range (2000-10000)")]
        public Double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
        [EmailAddress (ErrorMessage ="Email Is InValid")]
        public string Email { get; set; }
        [RegularExpression("[0-9]{1,5}-[a-zA-Z]{2,50}-[a-zA-Z]{2,50}-[a-zA-Z]{2,50}",
            ErrorMessage = "Enter Address Like 10-Street-City-Country")]
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime CreationDate { get; set; }
        public int? DistrictId { get; set; }
        public District District { get; set; }



    }
}
