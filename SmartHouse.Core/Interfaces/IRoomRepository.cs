using SmartHouse.Core.Entities.Rooms;
using System.Collections.Generic;

namespace SmartHouse.Core.Interfaces
{
    public interface IRoomRepository
    {        
        void AddRoom(Room room);
        IReadOnlyList<Room> GetRooms();        
    }
}
