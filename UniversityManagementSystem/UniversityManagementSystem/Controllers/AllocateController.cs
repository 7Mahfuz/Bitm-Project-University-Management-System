using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.ViewModel;

namespace UniversityManagementSystem.Controllers
{
    public class AllocateController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        CourseManager aCourseManager=new CourseManager();
        DayManager aDayManager=new DayManager();
        RoomManager aRoomManager=new RoomManager();
        AllocateManager aAllocateManager=new AllocateManager();

        
        public ActionResult Create()

        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");

            IEnumerable<Course> courses = new List<Course>();
            ViewBag.CourseList = new SelectList(courses, "Id", "Code");

            IEnumerable<Room> rooms =aRoomManager.GetAllRooms();
            ViewBag.RoomList = new SelectList(rooms, "Id", "RoomNumber");

            IEnumerable<Day> days = aDayManager.GetAllDays();
            ViewBag.DayList = new SelectList(days, "Id", "Name");
            return View();
        }

        public JsonResult GetCourseList(int departmentId)
        {
            IEnumerable<Course> coursesList = aCourseManager.GetCourseByDeptId(departmentId);
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");

            IEnumerable<Course> courses = new List<Course>();
            ViewBag.CourseList = new SelectList(courses, "Id", "Code");

            IEnumerable<Room> rooms = aRoomManager.GetAllRooms();
            ViewBag.RoomList = new SelectList(rooms, "Id", "RoomNumber");

            IEnumerable<Day> days = aDayManager.GetAllDays();
            ViewBag.DayList = new SelectList(days, "Id", "Name");

            try
            {
              string msg=  aAllocateManager.SaveAllocate(aAllocateClassRoomViewModel);

                if (msg == "Class room is Full in this Time Zone")
                {
                    ViewBag.message = msg;
                    return View();
                }

                ViewBag.message = msg;
                ModelState.Clear();
                return View(new AllocateClassRoomViewModel());
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ShowRoomAllocation()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");
            return View();
        }

        public JsonResult GetRoomInfoList(int departmentId)
        {
            IEnumerable<AllocateRoomViewModel> list = aAllocateManager.GetAllocateRoomList(departmentId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UnAllocateCourses()
        {
            return View();
        }
        public ActionResult UnAllocateAllCourses()
        {
            aAllocateManager.UnAllocateAllCourses();
            return RedirectToAction("UnAllocateCourses");
        }

        public ActionResult UnAllocateRooms()
        {
            return View();
        }
        public ActionResult UnAllocateAllRooms()
        {aAllocateManager.UnAllocateAllRooms();
            return RedirectToAction("UnAllocateRooms");
        }
    }
}
