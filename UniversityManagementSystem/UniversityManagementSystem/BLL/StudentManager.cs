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
            aStudent.Email = aStudentViewModel.Email;
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


      public string EnrollStudentSave(StudentEnrollViewModel aStudentEnrollViewModel)
      {

          if (CheckExist(aStudentEnrollViewModel))
          {
              return "This Student already have this Course";
          }
        StudentEnrollInCourse aStudentEnrollInCourse=new StudentEnrollInCourse();
        aStudentEnrollInCourse.StudentId = aStudentEnrollViewModel.StudentId;
        aStudentEnrollInCourse.CourseId = aStudentEnrollViewModel.CourseId;
        aStudentEnrollInCourse.Date = aStudentEnrollViewModel.Date;
          aStudentEnrollInCourse.IsAcTive = true;

        bool flag = aUnitOfWork.Repository<StudentEnrollInCourse>().InsertModel(aStudentEnrollInCourse);
        aUnitOfWork.Save();
          if (flag)
          {
              return "Course Succsefully Assigned";
          }
          else
          {
              return "Course Assign faailed <br> Try again";
          }
      }

        public bool CheckExist(StudentEnrollViewModel aStudentEnrollViewModel)
        {
            StudentEnrollInCourse aCourse =
                aUnitOfWork.Repository<StudentEnrollInCourse>()
                    .GetModel(
                        x =>
                            x.StudentId == aStudentEnrollViewModel.StudentId &&
                            x.CourseId == aStudentEnrollViewModel.CourseId);

            if (aCourse == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

      public string SaveResult(StudentResultViewModel aStudentResultViewModel)
      {
       Result aResult=new Result();
        aResult.StudentId = aStudentResultViewModel.StudentId;
        aResult.CourseId = aStudentResultViewModel.CourseId;
        aResult.Grade = aStudentResultViewModel.Grade;
          aResult.IsActive = true;
          if (CheckExist(aStudentResultViewModel))
          {
              Result aResult2 =
                  aUnitOfWork.Repository<Result>()
                      .GetModel(
                          x => x.StudentId == aResult.StudentId && x.CourseId == aResult.CourseId && x.IsActive == true);

              aResult2.Grade = aResult.Grade;

              bool flag = aUnitOfWork.Repository<Result>().UpdateModel(aResult2);
                aUnitOfWork.Save();
                if(flag)return "Resullt Updated";
          }

        bool flag2 = aUnitOfWork.Repository<Result>().InsertModel(aResult);
            aUnitOfWork.Save();
          if (flag2) return "Result Saved Succesfully";
          else return "Result saving failed";

      }

        public bool CheckExist(StudentResultViewModel aStudentResultViewModel)
        {
            Result aResult =
                aUnitOfWork.Repository<Result>()
                    .GetModel(
                        x =>
                            x.StudentId == aStudentResultViewModel.StudentId &&
                            x.CourseId == aStudentResultViewModel.CourseId && x.IsActive==true);

            if (aResult == null) return false;
            else return true;
        }
      public IEnumerable<Student> GetAllStudent()
      {
        IEnumerable<Student> students = aUnitOfWork.Repository<Student>().GetList();
        return students;
      }

      public IEnumerable<Course> GetCourseListByStudentIdForJson(int studentId)
      {
        Student aStudent = aUnitOfWork.Repository<Student>().GetModelById(studentId);
          IEnumerable<StudentEnrollInCourse> studentCourse =
              aUnitOfWork.Repository<StudentEnrollInCourse>()
                  .GetList(x => x.StudentId == studentId && x.IsAcTive == true);
            List<Course>courses=new List<Course>();
          foreach (var temp in studentCourse)
          {
              Course aCourse=new Course();
              aCourse = aUnitOfWork.Repository<Course>().GetModelById(temp.CourseId);
                courses.Add(aCourse);
          }

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

        public IEnumerable<ViewResultViewModel> GetResultListByStudentId(int studentId)
        {
            IEnumerable<StudentEnrollInCourse> studentCourse =
                aUnitOfWork.Repository<StudentEnrollInCourse>()
                    .GetList(x => x.StudentId == studentId && x.IsAcTive == true);
            List<ViewResultViewModel>resultList=new List<ViewResultViewModel>();
            foreach (var temp in studentCourse)
            {
                ViewResultViewModel aViewModel=new ViewResultViewModel();
                Result aResult =
                    aUnitOfWork.Repository<Result>()
                        .GetModel(x => x.StudentId == studentId && x.CourseId == temp.CourseId);

                Course aCourse = aCourseManager.GetACourse(temp.CourseId);
                aViewModel.Code = aCourse.Code;
                aViewModel.Name = aCourse.Name;
                if (aResult == null)
                {
                    aViewModel.Grade = "Not Graded Yet";
                }
                else
                {
                    aViewModel.Grade = aResult.Grade;
                }

                resultList.Add(aViewModel);
            }
            return resultList;
        } 

    }
}