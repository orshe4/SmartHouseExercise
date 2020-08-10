using SmartHouse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Core.Entities.Commands.Output
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
