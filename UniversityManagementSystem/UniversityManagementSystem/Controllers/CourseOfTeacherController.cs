using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseOfTeacherController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        CourseManager aCourseManager=new CourseManager();
        TeacherManager aTeacherManager=new TeacherManager();
        CourseAssignToTeacherManager aCourseAssignToTeacherManager=new CourseAssignToTeacherManager();


        public JsonResult GetTeacherList(int departmentId)
        {
            IEnumerable<Teacher> teachers = aTeacherManager.GetTeacherByDeptId(departmentId);
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseList(int departmentId)
        {
            IEnumerable<Course> coursesList = aCourseManager.GetCourseByDeptId(departmentId);
            IEnumerable<CourseAssignTeacher> assingList =
                aCourseAssignToTeacherManager.GetListByDepartmentId(departmentId);

            List<Course> courses = new List<Course>();

            foreach (var list in coursesList)
            {
                CourseAssignTeacher assign = assingList.FirstOrDefault(x => x.CourseId == list.Id);
                if(assign==null)
                { courses.Add(list);}
            }
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        private class TeacherCredit
        {
            public double TeacherCreditTo { get; set; }
            public double RemCredit { get; set; }
        }
        public JsonResult GetTeacherCredit(int teacherId)
        {
            if (teacherId == 0 || teacherId==null)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            Teacher aTeacher = aTeacherManager.GetATeacher(teacherId);
            IEnumerable<CourseAssignTeacher> CourseAssignTeacher = aCourseAssignToTeacherManager.GetListByTeacherId(teacherId);
            TeacherCredit aTeacherCredit=new TeacherCredit();
            aTeacherCredit.TeacherCreditTo = Convert.ToDouble(aTeacher.CreditToBeTaken);
            if (CourseAssignTeacher.Count()==0)
            {
                aTeacherCredit.RemCredit = 0;
            }
            else
            {
                double x = 0;
                foreach (var assignList in CourseAssignTeacher)
                {
                    
                    x += assignList.CreditTaken;
                }
                aTeacherCredit.RemCredit = Convert.ToDouble(aTeacher.CreditToBeTaken) - x;
            }
            return Json(aTeacherCredit, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetACourse(int courseId)
        {
            Course aCourse = aCourseManager.GetACourse(courseId);
            //var data = new {Name = aCourse.Name, Credit = aCourse.Credit};
            return Json(aCourse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseListByTeacherId(int teacherId,int departmentId)
        {
            
            IEnumerable<Course> coursesList = aCourseManager.GetCourseByDeptId(departmentId);
            IEnumerable<CourseAssignTeacher> assingList =
                aCourseAssignToTeacherManager.GetListByDepartmentId(departmentId);

            List<Course> courses = new List<Course>();

            foreach (var list in coursesList)
            {
                CourseAssignTeacher assign = assingList.FirstOrDefault(x => x.CourseId == list.Id);
                if (assign == null)
                { courses.Add(list); }
            }
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        // GET: CourseOfTeacher/Create
        public ActionResult Create()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");
            IEnumerable<Teacher>teachers=new List<Teacher>();
            ViewBag.TeacherList = new SelectList(teachers, "Id", "Name");
            IEnumerable<Course> courses = new List<Course>();
            ViewBag.CourseList = new SelectList(courses, "Id", "Code");
            

            return View();
        }

        // POST: CourseOfTeacher/Create
        [HttpPost]
        public ActionResult Create(CourseTeacherViewModel aCourseTeacherViewModel)
        {
            try
            {
                IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
                ViewBag.DeptList = new SelectList(departments, "Id", "Name");
                IEnumerable<Teacher> teachers = new List<Teacher>();
                ViewBag.TeacherList = new SelectList(teachers, "Id", "Name");
                IEnumerable<Course> courses = new List<Course>();
                ViewBag.CourseList = new SelectList(courses, "Id", "Code");


                string msg = aCourseAssignToTeacherManager.Save(aCourseTeacherViewModel);
                ViewBag.message = msg;
                ModelState.Clear();
                return View(new CourseTeacherViewModel() );
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AssignedCourseListShow()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");
            List<AssignedCourseListViewModel>list=new List<AssignedCourseListViewModel>();
            return View(list);
        }

        public JsonResult GetAssignedList(int departmentId)
        {
            List<AssignedCourseListViewModel> aViewModelOfAssignedCourseList =aCourseAssignToTeacherManager.GetAssignedListByDepartmentId(departmentId);
            return Json(aViewModelOfAssignedCourseList, JsonRequestBehavior.AllowGet);
        }
      
    }
}
