using CIK.Assignment5.WeatherData.Models;
using System.Collections.Generic;

namespace CIK.Assignment5.WeatherData.Services
{
    public interface ITemperatureAnalyzer
    {
        AnalyzerResultViewModel GetResult(IEnumerable<WeatherDataSample> data);
    }
}