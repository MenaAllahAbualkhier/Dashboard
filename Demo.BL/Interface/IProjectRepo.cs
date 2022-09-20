using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IProjectRepo
    {
        IEnumerable<project> Get();
        project GetById(int Id);
        void Update(project obj);
        void Delete(project obj);
        void Create(project obj);
        
    }
}
