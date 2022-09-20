﻿using Demo.BL.Models;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> Get();
        Department GetById(int id);
        void Create(Department obj);
        void Edit(Department obj);
        void Delete(Department obj);
        Department CreateWithReturn(Department obj);
        Department EditWithReturn(Department obj);
    }
}
