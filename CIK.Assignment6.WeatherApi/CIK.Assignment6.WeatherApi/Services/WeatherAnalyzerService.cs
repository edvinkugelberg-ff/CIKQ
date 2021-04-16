using CIK.Assignment6.WeatherApi.Services.Exceptions;
using CIK.Assignment6.WeatherApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIK.Assignment6.WeatherApi.Services
{
    public class WeatherAnalyzerService : IWeatherAnalyzerService
    {
        public TemparetureDataPointViewModel HighestTemperature(List<WeatherDataSample> data, DateIntervalInputModel timeInterval = default)
        {
            var intervalData = GetDataWithinInterval(data, timeInterval);

            var max = intervalData.Max(sample => sample.Value);

            return new TemparetureDataPointViewModel
            {
                Temperature = max,
                Time = intervalData.FirstOrDefault(sample => sample.Value == max).Time
            };
        }

        public TemparetureDataPointViewModel LowestTemperature(List<WeatherDataSample> data, DateIntervalInputModel timeInterval = default)
        {
            var intervalData = GetDataWithinInterval(data, timeInterval);

            var min = intervalData.Min(sample => sample.Value);

            return new TemparetureDataPointViewModel
            {
                Temperature = min,
                Time = intervalData.FirstOrDefault(sample => sample.Value == min).Time
            };
        }

        public TemperatureValueViewModel AverageTemperature(List<WeatherDataSample> data, DateIntervalInputModel timeInterval = default)
        {
            var intervalData = GetDataWithinInterval(data, timeInterval);

            return new TemperatureValueViewModel
            {
                Value = intervalData.Average(d => d.Value)
            };
        }

        private static List<WeatherDataSample> GetDataWithinInterval(List<WeatherDataSample> data, DateIntervalInputModel timeInterval)
        {
            if (timeInterval != default)
            {
                data = data.Where(d => d.Time > timeInterval.From && d.Time < timeInterval.To).ToList();
                if (data.Count == 0)
                {
                    throw new InvalidTimeIntervalException("The time interval is outside of data range");
                }
            }

            return data;
        }
    }
}
