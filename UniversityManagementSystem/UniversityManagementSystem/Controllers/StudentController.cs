﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        StudentManager aStudentManager=new StudentManager();
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View();
        }

        
        // GET: /Student/Create
        public ActionResult Create()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");
            StudentViewModel aStudent=new StudentViewModel();
            aStudent.Date=DateTime.Today;
            return View(aStudent);
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel aStudentViewModel)
        {
            try
            {
                string msg = aStudentManager.Save(aStudentViewModel);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

       
    }
}
