using CIK.Assignment5.WeatherData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Services.Analyzers
{
    public class LowestTemperature : ITemperatureAnalyzer
    {
        public AnalyzerResultViewModel GetResult(IEnumerable<WeatherDataSample> data)
        {
            var min = data.Min(sample => sample.Value);

            return new AnalyzerResultViewModel
            {
                Type = "Lowest temp",
                Value = min,
                Time = data.FirstOrDefault(sample => sample.Value == min).Time
            };
        }
    }
}
