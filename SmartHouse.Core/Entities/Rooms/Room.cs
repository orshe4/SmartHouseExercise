namespace SmartHouse.Core.Entities.Rooms
{
    public class Room
    {
        public string RoomName { get; }
        public RoomType RoomType { get; }

        public Room(string roomName, RoomType roomType)
        {
            RoomName = roomName;
            RoomType = roomType;
        }
    }
}
