using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouse.Core.Entities.Commands
{
    public class QueryActivityStatusCommand : Command
    {
        public QueryActivityStatusCommand() : base(CommandType.QueryActivityStatus)
        {
        }
    }
}
