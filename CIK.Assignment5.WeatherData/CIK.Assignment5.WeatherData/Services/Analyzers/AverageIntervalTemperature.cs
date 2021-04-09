using CIK.Assignment5.WeatherData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Services.Analyzers
{
    public class AverageIntervalTemperature : ITemperatureAnalyzer
    {
        private readonly int _minHour;
        private readonly int _maxHour;

        public AverageIntervalTemperature(int minHour, int maxHour)
        {
            _minHour = minHour;
            _maxHour = maxHour;
        }

        public AnalyzerResultViewModel GetResult(IEnumerable<WeatherDataSample> data)
        {
            var intervalData = from d in data
                          where d.Time.Hour > _minHour
                          where d.Time.Hour < _maxHour
                          select d;

            return new AnalyzerResultViewModel
            {
                Type = $"Average temp between {_minHour}:00 and {_maxHour}:00",
                Value = intervalData.Average(dtd => dtd.Value)
            };
        }
    }
}
