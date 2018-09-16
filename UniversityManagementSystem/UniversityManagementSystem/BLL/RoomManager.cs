using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class RoomManager
    {
        private GenericUnitOfWork aUnitOfWork = null;

        public RoomManager()
        {
            aUnitOfWork = new GenericUnitOfWork();
        }
        public RoomManager(GenericUnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            IEnumerable<Room> rooms = aUnitOfWork.Repository<Room>().GetList();
            return rooms;
        }
    }
}