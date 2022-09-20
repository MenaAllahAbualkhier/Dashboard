using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> Get();
        Employee GetById(int id);
        void Create(Employee obj);
        void Edit(Employee obj);
        void Delete(Employee obj);
        IEnumerable<Employee> SearchByName(string Name);
    }
}
