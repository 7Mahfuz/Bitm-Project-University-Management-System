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
            aAllocateClassRoom.TimeFrom = aAllocateClassRoomViewModel.TimeFrom;
            aAllocateClassRoom.To = aAllocateClassRoomViewModel.To;
            aAllocateClassRoom.TimeTo = aAllocateClassRoomViewModel.TimeTo;

            bool flag = aUnitOfWork.Repository<AllocateClassRoom>().InsertModel(aAllocateClassRoom);
            aUnitOfWork.Save();
        }

        public void CheckTime(AllocateClassRoomViewModel aAllocateClassRoomViewModel)
        {
            AllocateClassRoomViewModel tempAllocate = aAllocateClassRoomViewModel;
            IEnumerable<AllocateClassRoom> listInRooms =
                aUnitOfWork.Repository<AllocateClassRoom>()
                    .GetList(x => x.RoomId == aAllocateClassRoomViewModel.RoomId && x.IsAcTive == true);

            foreach (AllocateClassRoom allocate in listInRooms)
            {
                
            }
        }

    }
}