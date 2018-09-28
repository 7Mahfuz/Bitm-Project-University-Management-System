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
        StudentManager aStudentManager=new StudentManager();
        DepartmentManager aDepartmentManager=new DepartmentManager();
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
        IEnumerable<ViewResultViewModel> resultList=new List<ViewResultViewModel>();
        public byte[] MakePDF(int studentId)
        {

            resultList = aStudentManager.GetResultListByStudentId(studentId);
         aDocument=new Document(PageSize.A4,0f,0f,0f,0f);
            aDocument.SetPageSize(PageSize.A4);
            aDocument.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontSyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(aDocument, _memoryStream);
            aDocument.Open();
            _pdfPTable.SetWidths(new float[]{20f,150f,100f});


            this.ReportHeader(studentId);
             this.ReportBody();
            _pdfPTable.HeaderRows = 2;
            aDocument.Add(_pdfPTable);
            aDocument.Close();
            return _memoryStream.ToArray();
        }


        public void ReportHeader(int studentid)
        {

            fontSyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Date : "+DateTime.Today.ToString("d")+"\n", fontSyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            fontSyle = FontFactory.GetFont("Tahoma", 20f, 1);
            _pdfPCell=new PdfPCell(new Phrase("PUBG University\n",fontSyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            Student aStudent = aStudentManager.GetAStudent(studentid);
            Department aDepartment = aDepartmentManager.GetADepartment(aStudent.DepartmentId);
            fontSyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("\n\nStudent Name : "+aStudent.Name+ "\n\nReg No : "+aStudent.RegNo+"\n\nDepartment : "+aDepartment.Name+"\n\nSemester : 1st"+"\n\nEmail : "+aStudent.Email+"\n\n", fontSyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();




            fontSyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase("\n -- Result -- \n\n", fontSyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
        }

        public void ReportBody()
        {
            fontSyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" Course Code ", fontSyle));
           _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
          _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.ExtraParagraphSpace = 5;
            _pdfPTable.AddCell(_pdfPCell);


            fontSyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" Course Name ", fontSyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);


            fontSyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" Grade ", fontSyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
             
            //Table Body
            fontSyle = FontFactory.GetFont("Tahoma", 10f, 1);

            foreach (ViewResultViewModel result in resultList)
            {
                _pdfPCell = new PdfPCell(new Phrase(result.Code, fontSyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 5;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(result.Name, fontSyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(result.Grade, fontSyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();
            }
        }
    }
}