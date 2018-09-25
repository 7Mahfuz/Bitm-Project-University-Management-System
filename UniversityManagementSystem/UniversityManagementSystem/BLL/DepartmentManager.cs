using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf.fonts.cmaps;
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
            aDepartment.Code = aDepartment.Code.ToUpper();
            aDepartment.Name = aDepartment.Name.ToUpper();
                bool flag = aUnitOfWork.Repository<Department>().InsertModel(aDepartment);
                aUnitOfWork.Save();
                return "Department Saved";
            

        }
        public string CodeCheck(string code)
         {
            int x = 0;
            string msg = "";
            code = code.ToUpper();
            x = aUnitOfWork.Repository<Department>().Count(a => a.Code == code);
            if (x > 0)
            {
                return "Code is already Exist";
                    
            }
            
            return null;
         }
        public string NameCheck(string name)
        {
            int x = 0;
            name = name.ToUpper();
            bool flag = false;
            x = aUnitOfWork.Repository<Department>().Count(a => a.Name == name);
            if (x > 0)
            {
                return "Name already Exist";
            }
            if (name == null)
            {
                return "Name can not empyty";
            }
            return null;
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