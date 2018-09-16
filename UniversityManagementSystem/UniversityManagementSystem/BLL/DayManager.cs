using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DayManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public DayManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public DayManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public IEnumerable<Day> GetAllDays()
        {
            IEnumerable<Day> days = aUnitOfWork.Repository<Day>().GetList();
            return days;
        } 
    }
}