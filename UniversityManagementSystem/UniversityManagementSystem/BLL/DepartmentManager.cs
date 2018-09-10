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

        public string Save(Department aDepartment)
        {
            string Exist = IsExist(aDepartment);

            if(Exist=="CodeExist")
            {
                return "Code is already Exist";
            }
            else if(Exist=="NameExist")
            {
                return "Name is already Exist";
            }
             else
            {
                bool flag = aUnitOfWork.Repository<Department>().InsertModel(aDepartment);
                aUnitOfWork.Save();
                return "Department Saved";
            }

        }

        public string IsExist(Department aDepartment)
        {
            int x = 0, y = 0;
            x = aUnitOfWork.Repository<Department>().Count(a => a.Code == aDepartment.Code);
             y= aUnitOfWork.Repository<Department>().Count(a => a.Name == aDepartment.Name);

            if(x>0 && y==0)
            {
                return "CodeExist";
            }
            else if(x==0 && y>0)
            {
                return "NameExist";
            }
            else
            {
                return "Ok";
            }

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