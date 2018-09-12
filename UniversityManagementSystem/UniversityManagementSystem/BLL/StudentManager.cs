﻿using System;
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

            Department aDepartment=


           // bool flag = aUnitOfWork.Repository<Student>().InsertModel(aStudent);
            return "Saved Succesfully";
        }

    }
}