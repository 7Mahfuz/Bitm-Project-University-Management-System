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
                string tempDate = aAllocateClassRoomViewModel.From.ToString("yyyy-MM-dd HH:mm:ss");
                aAllocateClassRoom.From = tempDate;
                tempDate = aAllocateClassRoomViewModel.To.ToString("yyyy-MM-dd HH:mm:ss");
                aAllocateClassRoom.To = tempDate;


                bool flag = aUnitOfWork.Repository<AllocateClassRoom>().InsertModel(aAllocateClassRoom);
                aUnitOfWork.Save();
                return "Class Room allocated Succesfully";
            }
            return "Class Room allocation failed, try some valid time";
        }

        public string CheckTime(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            AllocateClassRoomViewModel newAllocate = aAllocateClassRoomViewModel;
            IEnumerable<AllocateClassRoom> listInRooms =
                aUnitOfWork.Repository<AllocateClassRoom>()
                    .GetList(x => x.RoomId == newAllocate.RoomId && x.DayId==newAllocate.DayId && x.IsAcTive == true).ToList();

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
                DateTime oldForm = DateTime.Parse(oldAllocate.From);
                DateTime oldTo = DateTime.Parse(oldAllocate.To);

                if (newAllocate.From <= oldForm)
                {
                    if (newAllocate.To > oldForm)
                    {
                        msg = "Full";
                    }
                }
               else if (newAllocate.From > oldForm && newAllocate.From < oldTo)
                {
                    msg = "Full";
                }



                //if (newAllocate.From>=oldForm && newAllocate.To<=oldTo)
                //{
                //    msg = "Full";
                //}
                //else if (newAllocate.From <= oldForm && newAllocate.To >= oldTo)
                //{
                //    msg = "Full";
                //}
                //else if(newAllocate.From>oldForm && newAllocate.From<oldTo)
                //{
                //    msg = "Full";  
                //}
                //else if(newAllocate.From<=oldForm && newAllocate.To<=oldTo)
                //{
                //    msg = "Full"; 
                //}
                //else if (newAllocate.From <= oldForm && newAllocate.To > oldForm && newAllocate.To<oldTo)
                //{
                //    msg = "Full";
                //}


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
                aUnitOfWork.Repository<AllocateClassRoom>().GetList(x => x.DepartmentId == departmentId && x.IsAcTive==true);
           
            List<Course> tempList = aUnitOfWork.Repository<Course>().GetList(x => x.DepartmentId == departmentId).ToList();

            List<AllocateRoomViewModel>newList=new List<AllocateRoomViewModel>();

            foreach (Course allocateClassRoom in tempList)
            {
                AllocateRoomViewModel newAllocateRoom=new AllocateRoomViewModel();
                newAllocateRoom.Code = allocateClassRoom.Code;
                newAllocateRoom.Name = allocateClassRoom.Name;
                string info = "";

                int a = allocatedRoom.Count(x => x.CourseId == allocateClassRoom.Id && x.IsAcTive==true),b=a;
                List<AllocateClassRoom> forcourseList = allocatedRoom.Where(x => x.CourseId == allocateClassRoom.Id).ToList();
                foreach (AllocateClassRoom classRoom in forcourseList)
                {
                    b--;
                    DateTime from = DateTime.Parse(classRoom.From);
                    DateTime to = DateTime.Parse(classRoom.To);
                    Room aRoom = aUnitOfWork.Repository<Room>().GetModelById(classRoom.RoomId);
                        Day aDay = aUnitOfWork.Repository<Day>().GetModelById(classRoom.DayId);
                        info += "R.No : " + aRoom.RoomNumber + ", " + aDay.ShortName + ", " + from.ToString("hh:mm tt") + " - " +
                                to.ToString("hh:mm tt") + "";
                    if (b > 0)
                    {
                        info += ";<br/>";
                    }
                   

                }
                if (a == 0)
                {
                    newAllocateRoom.Info = "Not Scheduled Yet";
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

