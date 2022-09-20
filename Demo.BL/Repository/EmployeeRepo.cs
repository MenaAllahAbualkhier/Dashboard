using Demo.BL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class EmployeeRepo: IEmployeeRepo
    {
        private readonly DemoContext db;

        public EmployeeRepo(DemoContext db)
        {
            this.db = db;
        }
        public void Create(Employee obj)
        {
            db.Employee.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Employee obj)
        {
            db.Employee.Remove(obj);
            db.SaveChanges();
        }

        public void Edit(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Employee> Get()
        {
            var data = db.Employee.Include("Department").Select(a => a);
            return data;
        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
        public IEnumerable<Employee> SearchByName(string Name)
        {
            var data = db.Employee.Include("Department").Where(a => a.Name.Contains(Name));
            return data;
        }

    }
}
