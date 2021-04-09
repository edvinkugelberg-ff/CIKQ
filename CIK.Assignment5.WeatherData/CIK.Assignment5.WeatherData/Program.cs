using CIK.Assignment5.WeatherData.Models;
using CIK.Assignment5.WeatherData.Services;
using CIK.Assignment5.WeatherData.Services.Analyzers;
using System;

namespace CIK.Assignment5.WeatherData
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "C:\\Code\\CodeIsKing\\CIK.Assignment5.WeatherData\\temperatures.csv";
            IDataFetcher fetcher = new FileReader(filePath);

            var data = fetcher.GetData().GetAwaiter().GetResult();

            var analysisSteps = new ITemperatureAnalyzer[]
            {
                new HighestTemperature(),
                new LowestTemperature(),
                new AverageTemperature(),
                new AverageIntervalTemperature(8, 17),
                new AverageIntervalTemperature(0, 5),
            };

            foreach (var step in analysisSteps)
            {
                ResultPresenter.Present(step.GetResult(data));
            }
        }
    }
}
