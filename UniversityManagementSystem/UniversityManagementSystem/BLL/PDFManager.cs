using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

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


         int _totalColumn = 3;
        private Document aDocument;
        private Font fontSyle;
        PdfPTable _pdfPTable=new PdfPTable(3);
        private PdfPCell _pdfPCell;
        MemoryStream _memoryStream=new MemoryStream();

        public byte[] MakePDF(int studentId)
        {
         aDocument=new Document(PageSize.A4,0f,0f,0f,0f);
            aDocument.SetPageSize(PageSize.A4);
            aDocument.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontSyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(aDocument, _memoryStream);
            aDocument.Open();
            _pdfPTable.SetWidths(new float[]{20f,150f,100f});


            this.ReportHeader();
         
            _pdfPTable.HeaderRows = 2;
            aDocument.Add(_pdfPTable);
            aDocument.Close();
            return _memoryStream.ToArray();
        }


        private Void ReportHeader()
        {
            
        }

        
    }
}