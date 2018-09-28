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
            aCourse.Name = aCourse.Name.ToUpper();
            aCourse.Code = aCourse.Code.ToUpper();
            bool flag = aUnitOfWork.Repository<Course>().InsertModel(aCourse);
            aUnitOfWork.Save();
            return "Saved Succesfully";
        }

        public string CheckCode(string code)
        {
            int x = 0;
            code=code.ToUpper();
            string msg = "";
            x = aUnitOfWork.Repository<Course>().Count(a => a.Code == code);
            if (x > 0)
            {
                return "Code is already Exist";

            }
            
           
            return null;
        }

        public string CheckName(string name)
        {
            int x = 0;
            name = name.ToUpper();
            bool flag = false;
            x = aUnitOfWork.Repository<Course>().Count(a => a.Name == name);
            if (x > 0)
            {
                return "Name already Exist";
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

        public Course GetACourse(int courseId)
        {
            Course aCourse = aUnitOfWork.Repository<Course>().GetModelById(courseId);
            return aCourse;
        }
    }
}