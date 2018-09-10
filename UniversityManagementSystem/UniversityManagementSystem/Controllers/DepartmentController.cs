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
        public ActionResult Details(int id)
        {
            return View();
        }

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
                aDepartmentManager.Save(aDepartment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            Department aDepartment = aDepartmentManager.GetADepartment(id);
            return View(aDepartment);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department aDepartment)
        {
            try
            {
                aDepartmentManager.Update(aDepartment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            Department aDepartment = aDepartmentManager.GetADepartment(id);
            return View(aDepartment);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Department aDepartment)
        {
            try
            {
                aDepartmentManager.Delete(aDepartment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
