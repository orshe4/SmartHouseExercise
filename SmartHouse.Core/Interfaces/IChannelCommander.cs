using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using System.Threading.Tasks;

namespace SmartHouse.Core.Interfaces
{
    public interface IChannelCommander
    {
        Task ChangeDeviceChannel(string deviceId, int newChannel);
        Task ChangeDeviceChannel(RoomType roomType, DeviceType deviceType, int newChannel);
        Task<ChannelStatus> GetChannelStatus(string deviceId);
        Task<ChannelStatus> GetChannelStatus(RoomType roomType, DeviceType deviceType);
    }
}
