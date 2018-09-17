using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.EntityModel;

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

        public void SaveAllocate(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            AllocateClassRoom aAllocateClassRoom=new AllocateClassRoom();
            aAllocateClassRoom.IsAcTive = true;
            aAllocateClassRoom.RoomId = aAllocateClassRoomViewModel.RoomId;
            aAllocateClassRoom.CourseId = aAllocateClassRoomViewModel.CourseId;
            aAllocateClassRoom.DayId = aAllocateClassRoomViewModel.DayId;
            aAllocateClassRoom.DepartmentId = aAllocateClassRoomViewModel.DepartmentId;
            aAllocateClassRoom.From = aAllocateClassRoomViewModel.From;
          
            aAllocateClassRoom.To = aAllocateClassRoomViewModel.To;
           

            bool flag = aUnitOfWork.Repository<AllocateClassRoom>().InsertModel(aAllocateClassRoom);
            aUnitOfWork.Save();
        }

        public void CheckTime(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            AllocateClassRoomViewModel tempAllocate = aAllocateClassRoomViewModel;
            IEnumerable<AllocateClassRoom> listInRooms =
                aUnitOfWork.Repository<AllocateClassRoom>()
                    .GetList(x => x.RoomId == aAllocateClassRoomViewModel.RoomId && x.IsAcTive == true);

            if (listInRooms.Count() == 0)
            {
                
            }





            foreach (AllocateClassRoom allocate in listInRooms)
            {
                
            }
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
            foreach (Result result in results)
            {
                result.IsActive = false;
                aUnitOfWork.Repository<Result>().UpdateModel(result);
               
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
    }
}