using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Models
{
    public class WeatherDataSample
    {
        public DateTime Time { get; }
        public decimal Value { get; }

        public WeatherDataSample( DateTime time, decimal value )
        {
            Time = time;
            Value = value;
        }
    }
}
