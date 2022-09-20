using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface ICvInformationRepo
    {
        void AddCv(CvInformation data);
        IEnumerable<CvInformation> Get();
        void Delete(CvInformation model);
        CvInformation GetById(int id);
    }
}
