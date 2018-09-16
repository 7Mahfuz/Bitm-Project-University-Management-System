using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AllocateController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        CourseManager aCourseManager=new CourseManager();
        DayManager aDayManager=new DayManager();
        RoomManager aRoomManager=new RoomManager();
        AllocateManager aAllocateManager=new AllocateManager();

        // GET: Allocate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Allocate/Create
        public ActionResult Create()

        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");

            IEnumerable<Course> courses = aCourseManager.GetAllCourses();
            ViewBag.CourseList = new SelectList(courses, "Id", "Code");

            IEnumerable<Room> rooms =aRoomManager.GetAllRooms();
            ViewBag.RoomList = new SelectList(rooms, "Id", "RoomNumber");

            IEnumerable<Day> days = aDayManager.GetAllDays();
            ViewBag.DayList = new SelectList(days, "Id", "Name");
            return View();
        }

        // POST: Allocate/Create
        [HttpPost]
        public ActionResult Create(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");

            IEnumerable<Course> courses = aCourseManager.GetAllCourses();
            ViewBag.CourseList = new SelectList(courses, "Id", "Code");

            IEnumerable<Room> rooms = aRoomManager.GetAllRooms();
            ViewBag.RoomList = new SelectList(rooms, "Id", "Name");

            IEnumerable<Day> days = aDayManager.GetAllDays();
            ViewBag.DayList = new SelectList(days, "Id", "Name");

            try
            {
                aAllocateManager.SaveAllocate(aAllocateClassRoomViewModel);

                //DateTime from = aAllocateClassRoomViewModel.From;
                //int fromHour = from.Hour, fromMinute = from.Minute;
                //TimeSpan sDateTime = from.TimeOfDay;

                // TODO: Add insert logic here
                ModelState.Clear();
                return View(new AllocateClassRoomViewModel());
            }
            catch
            {
                return View();
            }
        }

        // GET: Allocate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Allocate/Edit/5
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

        // GET: Allocate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Allocate/Delete/5
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
