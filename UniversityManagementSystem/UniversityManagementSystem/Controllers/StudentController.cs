using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private DepartmentManager aDepartmentManager = new DepartmentManager();
        private StudentManager aStudentManager = new StudentManager();
        CourseManager aCourseManager=new CourseManager();
        public ActionResult Create()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");

            ViewBag.Date = DateTime.Today;
            return View();
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel aStudentViewModel)
        {
            try
            {
                IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
                ViewBag.DeptList = new SelectList(departments, "Id", "Name");
                string msg = aStudentManager.Save(aStudentViewModel);
                ViewBag.message = msg;
                ModelState.Clear();
                return View(new StudentViewModel());
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return View();
            }

        }


      public ActionResult EnrollInCourse()
      {
        IEnumerable<Student> students = aStudentManager.GetAllStudent();
        ViewBag.studentList=new SelectList(students,"Id","RegNo");

        List<Course>courses=new List<Course>();
        ViewBag.courseList = new SelectList(courses, "Id", "Name");
        return View();
      }

      public JsonResult GetCourseList(int studentId)
      {
        IEnumerable<Course> courses = aStudentManager.GetCourseListByStudentId(studentId);
        return Json(courses, JsonRequestBehavior.AllowGet);
      }
      public JsonResult GetStudent(int studentId)
      {
        Student aStudent = aStudentManager.GetAStudentWithDeptName(studentId);
        return Json(aStudent, JsonRequestBehavior.AllowGet);
      }

      [HttpPost]
      public ActionResult EnrollInCourse(StudentEnrollViewModel aStudentEnrollViewModel)
      {
        IEnumerable<Student> students = aStudentManager.GetAllStudent();
        ViewBag.studentList = new SelectList(students, "Id", "RegNo");

        List<Course> courses = new List<Course>();
        ViewBag.courseList = new SelectList(courses, "Id", "Name");
        aStudentManager.EnrollStudentSave(aStudentEnrollViewModel);

        ModelState.Clear();
        return View(new StudentResultViewModel());
      }


      public ActionResult SaveResult()
      {
        IEnumerable<Student> students = aStudentManager.GetAllStudent();
        ViewBag.studentList = new SelectList(students, "Id", "RegNo");

        List<Course> courses = new List<Course>();
        ViewBag.courseList = new SelectList(courses, "Id", "Name");
        return View();
      }
      [HttpPost]
      public ActionResult SaveResult(StudentResultViewModel aStudentResultViewModel)
      {
        IEnumerable<Student> students = aStudentManager.GetAllStudent();
        ViewBag.studentList = new SelectList(students, "Id", "RegNo");

        List<Course> courses = new List<Course>();
        ViewBag.courseList = new SelectList(courses, "Id", "Name");



        return View();
      }

    }
}
