using SmartHouse.Core.Interfaces;

namespace SmartHouse.Core.Entities.Commands
{
    public class DegreesStatus: ICommandOutput
    {
        public int Degrees { get; }

        public DegreesStatus(int degrees)
        {
            Degrees = degrees;
        }
    }
}
