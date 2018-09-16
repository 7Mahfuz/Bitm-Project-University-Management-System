using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.EntityModel;


namespace UniversityManagementSystem.BLL
{
    public class StudentManager
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        private GenericUnitOfWork aUnitOfWork = null;
      CourseManager aCourseManager=new CourseManager();

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


      public void EnrollStudentSave(StudentEnrollViewModel aStudentEnrollViewModel)
      {
        StudentEnrollInCourse aStudentEnrollInCourse=new StudentEnrollInCourse();
        aStudentEnrollInCourse.StudentId = aStudentEnrollViewModel.StudentId;
        aStudentEnrollInCourse.CourseId = aStudentEnrollViewModel.CourseId;
        aStudentEnrollInCourse.Date = aStudentEnrollViewModel.Date;
          aStudentEnrollInCourse.IsAcTive = true;

        bool flag = aUnitOfWork.Repository<StudentEnrollInCourse>().InsertModel(aStudentEnrollInCourse);
        aUnitOfWork.Save();

      }

      public void SaveResult(StudentResultViewModel aStudentResultViewModel)
      {
       Result aResult=new Result();
        aResult.StudentId = aStudentResultViewModel.StudentId;
        aResult.CourseId = aStudentResultViewModel.CourseId;
        aResult.Grade = aStudentResultViewModel.Grade;

        bool flag = aUnitOfWork.Repository<Result>().InsertModel(aResult);
      }

      public IEnumerable<Student> GetAllStudent()
      {
        IEnumerable<Student> students = aUnitOfWork.Repository<Student>().GetList();
        return students;
      }

      public IEnumerable<Course> GetCourseListByStudentId(int studentId)
      {
        Student aStudent = aUnitOfWork.Repository<Student>().GetModelById(studentId);
        IEnumerable<Course> courses = aCourseManager.GetCourseByDeptId(aStudent.DepartmentId);
        return courses;
      }

      public Student GetAStudent(int studentId)
      {
        Student aStudent = aUnitOfWork.Repository<Student>().GetModelById(studentId);
        return aStudent;
      }

      public Student GetAStudentWithDeptName(int studentId)
      {
        Student aStudent = aUnitOfWork.Repository<Student>().GetModelById(studentId);
        Department aDepartment = aUnitOfWork.Repository<Department>().GetModelById(aStudent.DepartmentId);
        aStudent.RegNo = aDepartment.Name;
        return aStudent;
      }



    }
}