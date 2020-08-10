using SmartHouse.Core.Entities.Commands;
using SmartHouse.Core.Entities.Commands.Output;
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



        #region Commands
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
    }
}
