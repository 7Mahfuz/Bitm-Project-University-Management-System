using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class AllocateManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public AllocateManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public AllocateManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }



    }
}