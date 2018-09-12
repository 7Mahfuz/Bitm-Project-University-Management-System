using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        // GET: Department
        public ActionResult Index()
        {
            IEnumerable<Department> departments = aDepartmentManager.GetAllDepartment();
            
            return View(departments);
        }

        // GET: Department/Details/5
       

        // GET: Department/Create
       
        public ActionResult Add()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Add(Department aDepartment)
        {
            try
            {
                bool errorStatus = false;
                string codeError = aDepartmentManager.CodeCheck(aDepartment.Code);
                if (codeError != null)
                {
                    ViewBag.CodeError = codeError;
                    errorStatus = true;
                }

                string nameError = aDepartmentManager.NameCheck(aDepartment.Name);
                if (nameError != null)
                {
                    ViewBag.NameError = nameError;
                    errorStatus = true;
                }

                if (errorStatus)
                {
                    return View(aDepartment);
                }

                aDepartmentManager.Save(aDepartment);
                ViewBag.CodeError = null;
                ViewBag.NameError = null;
                ViewBag.Msg = "Saved Succesfully";
                ModelState.Clear();
                return View(new Department());
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        

        // GET: Department/Delete/5
        
    }
}
