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
            
                bool flag = aUnitOfWork.Repository<Department>().InsertModel(aDepartment);
                aUnitOfWork.Save();
                return "Department Saved";
            

        }
        public string CodeCheck(string code)
         {
            int x = 0;
            string msg = "";
            x = aUnitOfWork.Repository<Department>().Count(a => a.Code == code);
            if (x == 0)
            {
                return "Code is already Exist";
                    
            }
            if (code ==null)
            {
                return "Code can not empyty";
            }
            if (code.Length < 2)
            {
               return "Code can not less than 2 character";
            }
            if (code.Length > 7)
            {
                msg = "Code can not more than 7 character";
            }
            if (code == "")
            {
                return "Code can not empyty";
            }
            return null;
         }
        public bool NameCheck(string name)
        {
            int x = 0;
            bool flag = false;
            x = aUnitOfWork.Repository<Department>().Count(a => a.Name == name);
            if (x == 0)
            {
                flag = true;
            }
            return flag;
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