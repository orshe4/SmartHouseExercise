namespace SmartHouse.Core.Entities.Commands
{
    public enum CommandType
    {
        TurnOn,
        TurnOff,
        ChangeDegrees,
        QueryDegrees,
        QueryActivityStatus,
        ChangeChannel,
        QueryChannel
    }
}
