using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AllocateController : Controller
    {
        

        // GET: Allocate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Allocate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Allocate/Create
        [HttpPost]
        public ActionResult Create(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
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
