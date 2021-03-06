﻿using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using System.Threading.Tasks;

namespace SmartHouse.Core.Interfaces
{
    public interface IActivityCommander
    {
        Task TurnOffDevice(string deviceId);
        Task TurnOffDevice(DeviceType deviceType);
        Task TurnOffDevice(RoomType roomType, DeviceType deviceType);
        Task TurnOnDevice(string deviceId);
        Task TurnOnDevice(DeviceType deviceType);
        Task TurnOnDevice(RoomType roomType, DeviceType deviceType);
        Task<ActivityStatus> GetActivityStatus(string deviceId);
        Task<ActivityStatus> GetActivityStatus(DeviceType deviceType);
        Task<ActivityStatus> GetActivityStatus(RoomType roomType, DeviceType deviceType);
    }
}
