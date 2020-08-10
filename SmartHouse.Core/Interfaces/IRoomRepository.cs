using SmartHouse.Core.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Core.Interfaces
{
    public interface IRoomRepository
    {        
        void AddRoom(Room room);
        IReadOnlyList<Room> GetRooms();        
    }
}
