using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using  UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        TeacherManager aTeacherManager=new TeacherManager();
        //
        // GET: /Teacher/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Teacher/Create
        public ActionResult Create()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.DeptList = new SelectList(departments, "Id", "Name");

            IEnumerable<TeacherDesignation> designations = aTeacherManager.GetDesignations();
            ViewBag.DesgList = new SelectList(designations, "Id", "Name");
            return View();
        }

        //
        // POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher aTeacher)
        {
            try
            {
                IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
                ViewBag.DeptList = new SelectList(departments, "Id", "Name");

                IEnumerable<TeacherDesignation> designations = aTeacherManager.GetDesignations();
                ViewBag.DesgList = new SelectList(designations, "Id", "Name");

                bool errorStatus = false;
                string creditError = aTeacherManager.CheckCredit(Convert.ToDouble(aTeacher.CreditToBeTaken));

                if (creditError != null)
                {
                    ViewBag.CreditError = creditError;
                    errorStatus = true;
                }

                if (errorStatus)
                {
                    return View(aTeacher);
                }

                string msg = aTeacherManager.Save(aTeacher);
                ViewBag.CreditError = null;
                ViewBag.Msg = msg;
                ModelState.Clear();

                return View(new Teacher());
            }
            catch
            {
                return View();
            }
        }

        

        
    }
}
