using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;


namespace UniversityManagementSystem.BLL
{
    public class StudentManager
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        private GenericUnitOfWork aUnitOfWork = null;

        public StudentManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public StudentManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public string Save(StudentViewModel aStudentViewModel)
        {
            Student aStudent=new Student();
            aStudent.Name = aStudentViewModel.Name;
            aStudent.Email = aStudentViewModel.ContactNo;
            aStudent.ContactNo = aStudentViewModel.ContactNo;
            aStudent.Date = aStudentViewModel.Date;
            aStudent.Address = aStudentViewModel.Address;
            aStudent.DepartmentId = aStudentViewModel.DepartmentId;

            int numberOfStudent = aUnitOfWork.Repository<Student>().Count(x=>x.DepartmentId==aStudent.DepartmentId);
            string numberStudent = "";
            if (numberOfStudent < 10)
            {
                numberStudent += "00" + (numberOfStudent+1).ToString();
            }
            else if (numberOfStudent > 9 && numberOfStudent < 100)
            {
                numberStudent += "0" + (numberOfStudent+1).ToString();
            }
            else
            {
                numberStudent += (numberOfStudent+1).ToString();
            }

            Department aDepartment = aUnitOfWork.Repository<Department>().GetModelById(aStudentViewModel.DepartmentId);
            string reg = "";

            foreach (char ch in aDepartment.Code)
            {
                if (char.IsLetter(ch))
                {
                    reg += ch;
                }
                else
                {
                    
                    break;
                }
            }
            reg += "-" + DateTime.Now.Year + "-" + numberStudent;
            aStudent.RegNo = reg;

             bool flag = aUnitOfWork.Repository<Student>().InsertModel(aStudent);
            aUnitOfWork.Save();
            return "Saved Succesfully";
        }

    }
}