using CIK.Assignment6.WeatherApi.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIK.Assignment6.WeatherApi.Services
{
    public interface IDataFetcher
    {
        Task<List<WeatherDataSample>> GetData();
    }
}