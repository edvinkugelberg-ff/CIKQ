using CIK.Assignment5.WeatherData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Services
{
    interface IDataFetcher
    {
        Task<List<WeatherDataSample>> GetData();
    }
}