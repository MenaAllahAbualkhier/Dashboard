using AutoMapper;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Demo.DAL.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<project, ProjectVM>();
            CreateMap<ProjectVM, project>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<CvInformation, CvInformationVM>();
            CreateMap<CvInformationVM, CvInformation>();


            CreateMap<ApplicationUser, RegistrationVM>();
            CreateMap<RegistrationVM, ApplicationUser>();

            CreateMap<ApplicationUser, UserVM>();
            CreateMap<UserVM, ApplicationUser>();

        }
    }
}
