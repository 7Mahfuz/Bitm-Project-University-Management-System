using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
using iTextSharp;

namespace UniversityManagementSystem.BLL
{
    public class PDFManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public PDFManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public PDFManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public byte[] MakePDF(int studentId)
        {
            
        }
    }
}