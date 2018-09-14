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
            IEnumerable<Course> courses = aCourseManager.GetCourseByDeptId(departmentId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseList(int departmentId)
        {
            IEnumerable<Course> courses = aCourseManager.GetCourseByDeptId(departmentId);

            foreach (Course aCourse in courses)
            {
                
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
            ViewBag.CourseList = new SelectList(courses, "Id", "Name");

            return View();
        }

        // POST: CourseOfTeacher/Create
        [HttpPost]
        public ActionResult Create(CourseTeacherViewModel aCourseTeacherViewModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseOfTeacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseOfTeacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseOfTeacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseOfTeacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
