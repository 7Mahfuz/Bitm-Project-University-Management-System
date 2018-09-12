using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        SemesterManager aSemesterManager=new SemesterManager();
        CourseManager aCourseManager=new CourseManager();

       
        // GET: /Course/Create
        public ActionResult Create()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList=new SelectList(departments,"Id","Name");

            IEnumerable<Semester> semesters = aSemesterManager.GetAllSemesters();
            ViewBag.SemList = new SelectList(semesters, "Id", "Name");

            return View();
        }

        //
        // POST: /Course/Create
        [HttpPost]
        public ActionResult Create(Course aCourse)
        {
            try
            {
                bool errorStatus = false;

                string codeError = aCourseManager.CheckCode(aCourse.Code);
                if (codeError != null)
                {
                    ViewBag.CodeError = codeError;
                    errorStatus = true;
                }

                string nameError = aCourseManager.CheckName(aCourse.Name);
                if (nameError != null)
                {
                    ViewBag.NameError = nameError;
                    errorStatus = true;
                }

                string creditError = aCourseManager.CheckCredit(Convert.ToDouble(aCourse.Credit));
                if (creditError != null)
                {
                    ViewBag.CreditError = creditError;
                    errorStatus = true;
                }
                IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
                ViewBag.DeptList = new SelectList(departments, "Id", "Name");

                IEnumerable<Semester> semesters = aSemesterManager.GetAllSemesters();
                ViewBag.SemList = new SelectList(semesters, "Id", "Name");
                if (errorStatus)
                {
                    
                    return View(aCourse);
                }

                string msg = aCourseManager.Save(aCourse);
                ViewBag.Msg = msg;
                 ModelState.Clear();
                
                return View(new Course());
            }
            catch
            {
                return View();
            }
        }

        

      
    }
}
