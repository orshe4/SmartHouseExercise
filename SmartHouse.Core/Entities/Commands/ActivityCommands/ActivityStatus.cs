using SmartHouse.Core.Interfaces;

namespace SmartHouse.Core.Entities.Commands
{
    public class ActivityStatus : ICommandOutput
    {
        public bool IsActive{ get; }

        public ActivityStatus(bool isActivity)
        {
            IsActive = isActivity;
        }
    }
}
