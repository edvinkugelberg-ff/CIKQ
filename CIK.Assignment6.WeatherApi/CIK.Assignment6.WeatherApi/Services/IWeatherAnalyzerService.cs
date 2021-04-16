using CIK.Assignment6.WeatherApi.Services.Models;
using System.Collections.Generic;

namespace CIK.Assignment6.WeatherApi.Services
{
    public interface IWeatherAnalyzerService
    {
        TemperatureValueViewModel AverageTemperature(List<WeatherDataSample> data, DateIntervalInputModel timeInterval = null);
        TemparetureDataPointViewModel HighestTemperature(List<WeatherDataSample> data, DateIntervalInputModel timeInterval = null);
        TemparetureDataPointViewModel LowestTemperature(List<WeatherDataSample> data, DateIntervalInputModel timeInterval = null);
    }
}