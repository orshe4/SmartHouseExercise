using System;

namespace SmartHouse.Core.Exceptions
{
    public class DegreesOutOfRangeException : ArgumentOutOfRangeException
    {
        public DegreesOutOfRangeException(int minDegrees, int maxDegrees, int actualValue) :
            base("targetDegrees", actualValue, $"Target degrees must be between {minDegrees} and {maxDegrees}")
        { }
    }
}
