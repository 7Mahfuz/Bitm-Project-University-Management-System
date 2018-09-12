using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public CourseManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public CourseManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void Save(Course aCourse)
        {
            
        }
    }
}