using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Exceptions;
using SmartHouse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHouse.Infrastructure.Data
{
    /// <summary>
    /// Simple repository with default devices and rooms
    /// In real application it can be EF repository
    /// </summary>
    public class SimpleSmartHouseRepository : IDeviceRepository, IRoomRepository
    {
        private readonly List<Room> _rooms;
        private readonly List<Device> _devices;

        public SimpleSmartHouseRepository()
        {
            _rooms = new List<Room>();
            _devices = new List<Device>();
            CreateDefaultDevicesAndRooms();
        }

        private void CreateDefaultDevicesAndRooms()
        {
            Room bedRoom = new Room("Danny's room", RoomType.Bedroom);
            Room livingRoom = new Room("Living room", RoomType.LivingRoom);
            TV bedRoomTv = new TV(bedRoom);
            TV livingRoomTv = new TV(livingRoom);
            Computer computer = new Computer();
            AirConditioner airConditioner = new AirConditioner(10, 30);
            Microwave microwave = new Microwave(maxDegrees: 30);
            AddRoom(bedRoom);
            AddRoom(livingRoom);
            AddDevice(bedRoomTv);
            AddDevice(livingRoomTv);
            AddDevice(computer);
            AddDevice(airConditioner);
            AddDevice(microwave);
        }

        public void AddDevice(Device device)
        {
            if (device.Room != null && !_rooms.Contains(device.Room))
            {
                throw new ArgumentException("Room not exists");
            }

            if (_devices.Contains(device))
            {
                throw new ArgumentException("Device already exists");
            }

            _devices.Add(device);
        }

        public void AddRoom(Room room)
        {
            if (_rooms.Contains(room))
            {
                throw new ArgumentException("Room already exists");
            }

            _rooms.Add(room);
        }

        public IReadOnlyList<Device> GetDevices() => _devices.AsReadOnly();

        public IReadOnlyList<Room> GetRooms() => _rooms.AsReadOnly();

        public Device GetDevice(string deviceId)
        {
            Device device = _devices.FirstOrDefault(device => device.Id == deviceId);

            if (device == null)
            {
                throw new DeviceNotFoundException(deviceId);
            }

            return device;
        }

        public Device GetDevice(RoomType roomType, DeviceType deviceType)
        {
            List<Device> devices = _devices
                .Where(device => device.Room.RoomType == roomType && device.DeviceType == deviceType)
                .ToList();

            if (devices.Count == 0)
            {
                throw new DeviceNotFoundException(roomType, deviceType);
            }

            if (devices.Count > 1)
            {
                throw new MultipleDevicesFoundException(roomType, deviceType);
            }

            return devices.First();
        }
    }
}
