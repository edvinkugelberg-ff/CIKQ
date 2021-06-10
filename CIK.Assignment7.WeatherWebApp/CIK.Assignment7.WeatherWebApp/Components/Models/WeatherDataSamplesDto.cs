using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIK.Assignment7.WeatherWebApp.Components.Models
{
    public class WeatherDataSamplesDto
    {
        public List<DataPoint> Data { get; set; }
    }

    public class DataPoint
    {
        public DateTime Time { get; set; }
        public decimal Value { get; set; }
    }
}
