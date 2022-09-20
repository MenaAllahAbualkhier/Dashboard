using Demo.BL.Interface;
using Demo.BL.Models;
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
    public class DepartmentRepo: IDepartmentRepo
    {
        private readonly DemoContext db;

        public DepartmentRepo(DemoContext db)
        {
            this.db = db;
        }
        public void Create(Department obj)
        {
            db.Department.Add(obj);
            db.SaveChanges();
        }
        public Department CreateWithReturn(Department obj)
        {
            var data = db.Department.Add(obj);
            db.SaveChanges();
            return db.Department.OrderBy(a => a.Id).LastOrDefault();
        }
        public void Delete(Department obj)
        {
            db.Department.Remove(obj);
            db.SaveChanges();
        }

        public void Edit(Department obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public Department EditWithReturn(Department obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return db.Department.Find(obj.Id);
 
        }

        public IEnumerable<Department>Get()
        {
            var data = db.Department.Select(a => a);
            return data;
        }

        public Department GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

       
    }
}
