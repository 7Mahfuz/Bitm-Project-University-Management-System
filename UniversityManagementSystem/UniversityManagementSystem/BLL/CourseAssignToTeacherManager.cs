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

        CourseManager aCourseManager=new CourseManager();
        SemesterManager aSemesterManager = new SemesterManager();
        TeacherManager aTeacherManager=new TeacherManager();


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
        public CourseAssignTeacher GetAssignDataByCourseId(int courseId)
        {
            CourseAssignTeacher aCourseAssignTeacher =
                aUnitOfWork.Repository<CourseAssignTeacher>().GetModel(x=>x.CourseId==courseId);
            return aCourseAssignTeacher;
        }

        public List<AssignedCourseListViewModel> GetAssignedListByDepartmentId(int departmentId)
        {
            IEnumerable<Course> courses = aUnitOfWork.Repository<Course>().GetList(x => x.DepartmentId == departmentId);
            List<AssignedCourseListViewModel>aViewModelOfAssignedCourse=new List<AssignedCourseListViewModel>();
            foreach (Course aCourse in courses)
            {
                CourseAssignTeacher aCourseAssignTeacher = GetAssignDataByCourseId(aCourse.Id);
                Semester aSemester = aSemesterManager.GetASemester(aCourse.SemesterId);
                AssignedCourseListViewModel aAssignedCourse=new AssignedCourseListViewModel();
                aAssignedCourse.Code = aCourse.Code;
                aAssignedCourse.Name = aCourse.Name;
                aAssignedCourse.Semester = aSemester.Name;
                if (aCourseAssignTeacher == null)
                {
                    aAssignedCourse.AssignedTo = "Not Assigned";
                        ;
                }
                else
                {
                    Teacher aTeacher = aTeacherManager.GetATeacher(aCourseAssignTeacher.TeacherId);
                    aAssignedCourse.AssignedTo = aTeacher.Name;
                }
                aViewModelOfAssignedCourse.Add(aAssignedCourse);
            }
            return aViewModelOfAssignedCourse;
        }
    }
}