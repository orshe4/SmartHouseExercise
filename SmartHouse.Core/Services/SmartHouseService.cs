using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Devices;
using SmartHouse.Core.Entities.Rooms;
using SmartHouse.Core.Interfaces;
using System.Threading.Tasks;

namespace SmartHouse.Core.Services
{
    public class SmartHouseService : ISmartHouseService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ICommandSender _commandSender;

        public SmartHouseService(IDeviceRepository deviceRepository, ICommandSender commandSender)
        {
            _deviceRepository = deviceRepository;
            _commandSender = commandSender;
        }

        #region IActivityCommander
        public async Task<ActivityStatus> GetActivityStatus(string deviceId) =>
            await GetActivityStatus(_deviceRepository.GetDevice(deviceId));

        public async Task<ActivityStatus> GetActivityStatus(RoomType roomType, DeviceType deviceType) =>
            await GetActivityStatus(_deviceRepository.GetDevice(roomType, deviceType));

        public async Task TurnOffDevice(string deviceId) =>
            await TurnOffDevice(_deviceRepository.GetDevice(deviceId));

        public async Task TurnOffDevice(RoomType roomType, DeviceType deviceType) =>
            await TurnOffDevice(_deviceRepository.GetDevice(roomType, deviceType));

        public async Task TurnOnDevice(string deviceId) =>
            await TurnOnDevice(_deviceRepository.GetDevice(deviceId));

        public async Task TurnOnDevice(RoomType roomType, DeviceType deviceType) =>
            await TurnOnDevice(_deviceRepository.GetDevice(roomType, deviceType));

        public async Task TurnOffDevice(DeviceType deviceType) =>
            await TurnOffDevice(_deviceRepository.GetDevice(deviceType));

        public async Task TurnOnDevice(DeviceType deviceType) =>
            await TurnOnDevice(_deviceRepository.GetDevice(deviceType));

        public async Task<ActivityStatus> GetActivityStatus(DeviceType deviceType) =>
            await GetActivityStatus(_deviceRepository.GetDevice(deviceType));

        private async Task TurnOffDevice(Device device)
        {
            TurnOffCommand turnOffCommand = new TurnOffCommand();
            await _commandSender.SendCommand(device, turnOffCommand);
        }

        private async Task TurnOnDevice(Device device)
        {
            TurnOnCommand turnOffCommand = new TurnOnCommand();
            await _commandSender.SendCommand(device, turnOffCommand);
        }

        private async Task<ActivityStatus> GetActivityStatus(Device device)
        {
            QueryActivityStatusCommand turnOffCommand = new QueryActivityStatusCommand();
            return (ActivityStatus)await _commandSender.SendCommand(device, turnOffCommand);
        }
        #endregion

        #region IChannelCommander
        public async Task ChangeDeviceChannel(string deviceId, int newChannel) =>
            await ChangeChannel(_deviceRepository.GetDevice(deviceId), newChannel);
        public async Task ChangeDeviceChannel(RoomType roomType, DeviceType deviceType, int newChannel) =>
            await ChangeChannel(_deviceRepository.GetDevice(roomType, deviceType), newChannel);
        public async Task<ChannelStatus> GetChannelStatus(string deviceId) =>
            await GetChannelStatus(_deviceRepository.GetDevice(deviceId));

        public async Task<ChannelStatus> GetChannelStatus(RoomType roomType, DeviceType deviceType) =>
            await GetChannelStatus(_deviceRepository.GetDevice(roomType, deviceType));

        public async Task ChangeDeviceChannel(DeviceType deviceType, int newChannel) =>
            await ChangeChannel(_deviceRepository.GetDevice(deviceType), newChannel);

        public async Task<ChannelStatus> GetChannelStatus(DeviceType deviceType) =>
            await GetChannelStatus(_deviceRepository.GetDevice(deviceType));

        private async Task<ChannelStatus> GetChannelStatus(Device device)
        {
            QueryChannelCommand queryChannelCommand = new QueryChannelCommand();
            return (ChannelStatus)await _commandSender.SendCommand(device, queryChannelCommand);
        }


        private async Task ChangeChannel(Device device, int newChannel)
        {
            ChangeChannelCommand command = new ChangeChannelCommand(newChannel);
            await _commandSender.SendCommand(device, command);
        }

        #endregion

        #region IDegreesCommander
        public async Task ChangeDeviceDegrees(string deviceId, int newDegrees) =>
            await ChangeDegrees(_deviceRepository.GetDevice(deviceId), newDegrees);

        public async Task ChangeDeviceDegrees(RoomType roomType, DeviceType deviceType, int newDegrees) =>
            await ChangeDegrees(_deviceRepository.GetDevice(roomType, deviceType), newDegrees);

        public async Task<DegreesStatus> GetDegreesStatus(string deviceId) =>
            await GetDegrees(_deviceRepository.GetDevice(deviceId));
        public async Task<DegreesStatus> GetDegreesStatus(RoomType roomType, DeviceType deviceType) =>
            await GetDegrees(_deviceRepository.GetDevice(roomType, deviceType));

        public async Task ChangeDeviceDegrees(DeviceType deviceType, int newDegrees) =>
            await ChangeDegrees(_deviceRepository.GetDevice(deviceType), newDegrees);
        public async Task<DegreesStatus> GetDegreesStatus(DeviceType deviceType) =>
            await GetDegrees(_deviceRepository.GetDevice(deviceType));

        private async Task ChangeDegrees(Device device, int newDegrees)
        {
            ChangeDegreesCommand changeDegreesCommand = new ChangeDegreesCommand(newDegrees);
            await _commandSender.SendCommand(device, changeDegreesCommand);
        }

        private async Task<DegreesStatus> GetDegrees(Device device)
        {
            QueryDegreesCommand command = new QueryDegreesCommand();
            return (DegreesStatus)await _commandSender.SendCommand(device, command);
        }
        #endregion
    }
}
