using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public DepartmentManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public DepartmentManager (GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void Save(Department aDepartment)
        {
            bool flag = aUnitOfWork.Repository<Department>().InsertModel(aDepartment);
            aUnitOfWork.Save();
        }

        public void Delete(Department aDepartment)
        {
            bool flag = aUnitOfWork.Repository<Department>().DeleteModel(aDepartment);
            aUnitOfWork.Save();
        }
        public void Update(Department aDepartment)
        {
            bool flag = aUnitOfWork.Repository<Department>().UpdateModel(aDepartment);
            aUnitOfWork.Save();
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            IEnumerable<Department> departments = aUnitOfWork.Repository<Department>().GetList();
            return departments;
        }
        public Department GetADepartment(int departmentId)
        {
            Department aDepartment = aUnitOfWork.Repository<Department>().GetModelById(departmentId);
            return aDepartment;
        }

    }
}