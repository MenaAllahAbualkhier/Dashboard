using Demo.BL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class CityRepo: ICityRepo
    {
        private readonly DemoContext db;

        public CityRepo(DemoContext db)
        {
            this.db = db;
        }
        IEnumerable<City> ICityRepo.Get(Expression<Func<City,bool>> filter=null )
        {
            if (filter == null)
            {
                var data = db.City.Select(a => a);
                return data;
            }
            else
            {
                return db.City.Where(filter);
            }
        }
        public City GetById(int id)
        {
            var data = db.City.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

      



    }
}
