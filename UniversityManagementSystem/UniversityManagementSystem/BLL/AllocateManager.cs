using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.EntityModel;
using UniversityManagementSystem.Models.ViewModel;

namespace UniversityManagementSystem.BLL
{
    public class AllocateManager
    {
        CourseManager aCourseManager=new CourseManager();

        private GenericUnitOfWork aUnitOfWork = null;

        public AllocateManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public AllocateManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public string SaveAllocate(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            string msg=CheckTime(aAllocateClassRoomViewModel);

            if (msg == "Full")
            {
                return "Class room is Full in this Time Zone";
            }

            if (msg == "Ok")
            {
                AllocateClassRoom aAllocateClassRoom = new AllocateClassRoom();
                aAllocateClassRoom.IsAcTive = true;
                aAllocateClassRoom.RoomId = aAllocateClassRoomViewModel.RoomId;
                aAllocateClassRoom.CourseId = aAllocateClassRoomViewModel.CourseId;
                aAllocateClassRoom.DayId = aAllocateClassRoomViewModel.DayId;
                aAllocateClassRoom.DepartmentId = aAllocateClassRoomViewModel.DepartmentId;
                aAllocateClassRoom.From = aAllocateClassRoomViewModel.From;

                aAllocateClassRoom.To = aAllocateClassRoomViewModel.To;


                bool flag = aUnitOfWork.Repository<AllocateClassRoom>().InsertModel(aAllocateClassRoom);
                aUnitOfWork.Save();
                return "Class Room allocated Succesfully";
            }
            return "Class Room allocation failed";
        }

        public string CheckTime(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            AllocateClassRoomViewModel newAllocate = aAllocateClassRoomViewModel;
            IEnumerable<AllocateClassRoom> list =
                aUnitOfWork.Repository<AllocateClassRoom>()
                    .GetList(x => x.RoomId == newAllocate.RoomId && x.DayId==newAllocate.DayId && x.IsAcTive == true);

            List<AllocateClassRoom> listInRooms =new List<AllocateClassRoom>();
            foreach (AllocateClassRoom room in list)
            {
                listInRooms.Add(room);
            }

            if (newAllocate.From> newAllocate.To)
            {
                return "InValid";
            }
            
            if (listInRooms.Count()==0)
            {
                return "Ok";
            }
            string msg = "Ok";
            foreach (AllocateClassRoom oldAllocate in listInRooms)
            {
                if (newAllocate.From>oldAllocate.From && newAllocate.To<oldAllocate.To)
                {
                    msg = "Full";
                }
                else if (newAllocate.From < oldAllocate.From && newAllocate.To > oldAllocate.To)
                {
                    msg = "Full";
                }
                else if(newAllocate.From>oldAllocate.From && newAllocate.From<oldAllocate.To)
                {
                    msg = "Full";  
                }
                else if(newAllocate.From<oldAllocate.From && newAllocate.To>oldAllocate.From && newAllocate.To<oldAllocate.To)
                {
                    msg = "Full"; 
                }



            }
            return msg;
        }

        public void UnAllocateAllCourses()
        {
            IEnumerable<StudentEnrollInCourse> courses = aUnitOfWork.Repository<StudentEnrollInCourse>().GetList();
            foreach (StudentEnrollInCourse aCourse in courses)
            {
                aCourse.IsAcTive = false;
                aUnitOfWork.Repository<StudentEnrollInCourse>().UpdateModel(aCourse);
                
            }

            IEnumerable<CourseAssignTeacher> teacherCourse = aUnitOfWork.Repository<CourseAssignTeacher>().GetList();
            foreach (CourseAssignTeacher teacher in teacherCourse)
            {
                teacher.IsActive = false;
                aUnitOfWork.Repository<CourseAssignTeacher>().UpdateModel(teacher);
                
            }

            IEnumerable<Result> results = aUnitOfWork.Repository<Result>().GetList();
            if (results.ToList().Count() > 0)
            {
                foreach (Result result in results)
                {
                    result.IsActive = false;
                    aUnitOfWork.Repository<Result>().UpdateModel(result);

                }
            }
            
            aUnitOfWork.Save();
        }

        public void UnAllocateAllRooms()
        {
            IEnumerable<AllocateClassRoom> rooms = aUnitOfWork.Repository<AllocateClassRoom>().GetList();
            foreach (AllocateClassRoom room in rooms)
            {
                room.IsAcTive = false;
                aUnitOfWork.Repository<AllocateClassRoom>().UpdateModel(room);
            }
            aUnitOfWork.Save();
        }

        public List<AllocateRoomViewModel> GetAllocateRoomList(int departmentId)
        {
            IEnumerable<AllocateClassRoom> allocatedRoom =
                aUnitOfWork.Repository<AllocateClassRoom>().GetList(x => x.DepartmentId == departmentId);

            List<AllocateClassRoom> tempList = allocatedRoom.DistinctBy(x => x.DepartmentId).ToList();

            List<AllocateRoomViewModel>newList=new List<AllocateRoomViewModel>();

            foreach (AllocateClassRoom allocateClassRoom in tempList)
            {
                AllocateRoomViewModel newAllocateRoom=new AllocateRoomViewModel();
                Course aCourse = aUnitOfWork.Repository<Course>().GetModelById(allocateClassRoom.CourseId);
                newAllocateRoom.Code = aCourse.Code;
                newAllocateRoom.Name = aCourse.Name;
                string info = "";

                int a = allocatedRoom.Count(x => x.CourseId == aCourse.Id),b=a;
                List<AllocateClassRoom> forcourseList = allocatedRoom.Where(x => x.CourseId == aCourse.Id).ToList();
                foreach (AllocateClassRoom classRoom in forcourseList)
                {
                    b--;
                    Room aRoom = aUnitOfWork.Repository<Room>().GetModelById(classRoom.RoomId);
                        Day aDay = aUnitOfWork.Repository<Day>().GetModelById(classRoom.DayId);
                        info += "R.No : " + aRoom.RoomNumber + ", " + aDay.ShortName + ", " + classRoom.From.ToString("hh:mm tt") + " - " +
                                classRoom.To.ToString("hh:mm tt") + "";
                    if (b > 0)
                    {
                        info += ";<br/><br>";
                    }
                   

                }
                if (a == 0)
                {
                    newAllocateRoom.Info = "<br/>No Room has been assignned<br/>";
                }
                else
                {
                    newAllocateRoom.Info = info;
                }
                
                newList.Add(newAllocateRoom);
            }
            return newList;
        }

    }
}

