using CIK.Assignment5.WeatherData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Services.Analyzers
{
    public class AverageTemperature : ITemperatureAnalyzer
    {
        public AnalyzerResultViewModel GetResult(IEnumerable<WeatherDataSample> data)
        {
            return new AnalyzerResultViewModel
            {
                Type = "Average temp",
                Value = data.Average(samples => samples.Value)
            };
        }
    }
}
