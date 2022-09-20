using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
    public class CvInformationVM
    {
        public int Id { get; set; }
        public string CvName { get; set; }
        public string PhotoName { get; set; }
        public IFormFile CV { get; set; }
        public IFormFile Photo { get; set; }
    }
}
