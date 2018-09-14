using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseAssignToTeacherManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public CourseAssignToTeacherManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public CourseAssignToTeacherManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }


    }
}