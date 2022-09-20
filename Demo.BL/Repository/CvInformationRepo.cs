using Demo.BL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class CvInformationRepo: ICvInformationRepo
    {
        private readonly DemoContext db;

        public CvInformationRepo(DemoContext db)
        {
            this.db = db;
        }

        public void AddCv (CvInformation data)
        {
            db.CvInformation.Add(data);
            db.SaveChanges();
        }
        public IEnumerable<CvInformation> Get()
        {
            var data = db.CvInformation.Select(a => a);
            return data;
        }
        public void Delete(CvInformation model)
        {
           
            db.CvInformation.Remove(model);
            db.SaveChanges();

        }
        public CvInformation GetById(int id)
        {
            var data = db.CvInformation.Find(id);
            return data;
        }

    }
}
