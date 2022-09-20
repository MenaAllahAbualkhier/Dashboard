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
    public class ProjectRepo:IProjectRepo
    {
        private readonly DemoContext db;
        public ProjectRepo(DemoContext db)
        {
            this.db = db;
        }
        public IEnumerable<project> Get()
        {
            var data = db.project.Include("Department").Select(a => a);
            return data;
        }
        public project GetById(int Id)
        {
            var data = db.project.Where(a => a.Id == Id).FirstOrDefault();
            return data;
        }
        public void Create(project obj)
        {
            db.project.Add(obj);
            db.SaveChanges();
        }
        public void Update(project obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(project obj)
        {
            db.project.Remove(obj);
            db.SaveChanges();
        }
    }
}
