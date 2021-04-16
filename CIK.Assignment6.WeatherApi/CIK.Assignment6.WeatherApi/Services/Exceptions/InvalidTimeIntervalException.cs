using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIK.Assignment6.WeatherApi.Services.Exceptions
{
    public class InvalidTimeIntervalException : Exception
    {
        public InvalidTimeIntervalException(string message) : base(message)
        {
        }
    }
}
