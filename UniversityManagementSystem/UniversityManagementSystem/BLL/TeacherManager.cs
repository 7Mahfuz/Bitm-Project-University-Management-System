using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public TeacherManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public TeacherManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public String Save(Teacher aTeacher)
        {
            bool flag = aUnitOfWork.Repository<Teacher>().InsertModel(aTeacher);
            aUnitOfWork.Save();
            return "Saved Succesfully";
        }


        public string CheckCredit(double credit)
        {
            if (credit < 0)
            {
                return "Credit can not be negative";
            }
            return null;
        }


        public IEnumerable<TeacherDesignation> GetDesignations()
        {
            IEnumerable<TeacherDesignation> teacherDesignations = aUnitOfWork.Repository<TeacherDesignation>().GetList();
            return teacherDesignations;
        }

        public IEnumerable<Teacher> GetTeacherByDeptId(int deptId)
        {
            IEnumerable<Teacher> teachers = aUnitOfWork.Repository<Teacher>().GetList(x => x.DepartmentId == deptId);
            return teachers;
        } 

    }
}