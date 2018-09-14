using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class SemesterManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public SemesterManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public SemesterManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }


        public IEnumerable<Semester> GetAllSemesters()
        {
            IEnumerable<Semester> semesters = aUnitOfWork.Repository<Semester>().GetList();
            return semesters;
        }

        public Semester GetASemester(int semesterId)
        {
            Semester aSemester = aUnitOfWork.Repository<Semester>().GetModelById(semesterId);
            return aSemester;
        }
    }
}