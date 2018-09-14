using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {


        private GenericUnitOfWork aUnitOfWork = null;

        public CourseManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public CourseManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public string Save(Course aCourse)
        {
            bool flag = aUnitOfWork.Repository<Course>().InsertModel(aCourse);
            aUnitOfWork.Save();
            return "Saved Succesfully";
        }

        public string CheckCode(string code)
        {
            int x = 0;
            string msg = "";
            x = aUnitOfWork.Repository<Course>().Count(a => a.Code == code);
            if (x > 0)
            {
                return "Code is already Exist";

            }
            if (code == null)
            {
                return "Code can not empyty";
            }
           
            if (code.Length <5)
            {
                return "Code must be at least 5 character";
            }
           
            return null;
        }

        public string CheckName(string name)
        {
            int x = 0;
            bool flag = false;
            x = aUnitOfWork.Repository<Course>().Count(a => a.Name == name);
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

        public string CheckCredit(double credit)
        {
            if (credit < 0.5 || credit > 5.0)
            {
                return "Credit must be between 0.5 to 5.0";
            }

            return null;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = aUnitOfWork.Repository<Course>().GetList();
            return courses;
        }

        public IEnumerable<Course> GetCourseByDeptId(int deptId)
        {
            IEnumerable<Course> courses = aUnitOfWork.Repository<Course>().GetList(x => x.DepartmentId == deptId);
            return courses;
        } 
    }
}