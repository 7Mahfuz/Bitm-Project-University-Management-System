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


        public string Save(CourseTeacherViewModel aCourseTeacherViewModel)
        {
            CourseAssignTeacher aCourseAssignTeacher=new CourseAssignTeacher();
            aCourseAssignTeacher.TeacherId = aCourseTeacherViewModel.TeacherId;
            aCourseAssignTeacher.DepartmentId = aCourseTeacherViewModel.DepartmentId;
            aCourseAssignTeacher.CourseId = aCourseTeacherViewModel.CourseId;
            aCourseAssignTeacher.CreditTaken = aCourseTeacherViewModel.CourseCredit;
                bool flag = aUnitOfWork.Repository<CourseAssignTeacher>().InsertModel(aCourseAssignTeacher);
                aUnitOfWork.Save();
                
           
            return "Assigned Successfully";
        }

        public CourseAssignTeacher GetAssignDataByTeacherId(int teacherId)
        {
            CourseAssignTeacher aCourseAssignTeacher =
                aUnitOfWork.Repository<CourseAssignTeacher>().GetModel(x => x.TeacherId == teacherId);
            return aCourseAssignTeacher;
        }

        public IEnumerable<CourseAssignTeacher> GetListByTeacherId(int teacherId)
        {
            IEnumerable<CourseAssignTeacher> assignList =
                aUnitOfWork.Repository<CourseAssignTeacher>().GetList(x => x.TeacherId == teacherId);
            return assignList;
        }

        public IEnumerable<CourseAssignTeacher> GetListByDepartmentId(int deptId)
        {
            IEnumerable<CourseAssignTeacher> assignList =
                aUnitOfWork.Repository<CourseAssignTeacher>().GetList(x => x.DepartmentId == deptId);
            return assignList;
        }
        public CourseAssignTeacher GetAssignDataByTeacherIdCourseId(int teacherId,int courseId)
        {
            CourseAssignTeacher aCourseAssignTeacher =
                aUnitOfWork.Repository<CourseAssignTeacher>().GetModel(x => x.TeacherId == teacherId && x.CourseId==courseId);
            return aCourseAssignTeacher;
        }
    }
}