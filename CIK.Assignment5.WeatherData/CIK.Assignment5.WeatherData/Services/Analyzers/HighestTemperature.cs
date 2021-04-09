using CIK.Assignment5.WeatherData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Services.Analyzers
{
    public class HighestTemperature : ITemperatureAnalyzer
    {
        public AnalyzerResultViewModel GetResult(IEnumerable<WeatherDataSample> data)
        {
            var max = data.Max(sample => sample.Value);

            return new AnalyzerResultViewModel
            {
                Type = "Highest temp",
                Value = max,
                Time = data.FirstOrDefault(sample => sample.Value == max).Time
            };
        }
    }
}
