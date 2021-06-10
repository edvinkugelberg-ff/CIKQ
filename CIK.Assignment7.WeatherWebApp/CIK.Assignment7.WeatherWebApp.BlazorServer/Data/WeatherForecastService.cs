using CIK.Assignment7.WeatherWebApp.BlazorServer.Components.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CIK.Assignment7.WeatherWebApp.BlazorServer.Data
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherDataSamplesDto> GetWeatherDataAsync()
        {
            var responseMessage = await _httpClient.GetAsync(new Uri("https://localhost:44309/api/weather/data"));
            var weatherDataJson = await responseMessage.Content.ReadAsStringAsync();
            var deserializedWeatherData = JsonConvert.DeserializeObject<List<DataPoint>>(weatherDataJson);

            return new WeatherDataSamplesDto { Data = deserializedWeatherData };
        }
    }
}
