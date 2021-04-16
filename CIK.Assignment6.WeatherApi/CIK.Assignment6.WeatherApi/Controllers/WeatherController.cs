using CIK.Assignment6.WeatherApi.Services;
using CIK.Assignment6.WeatherApi.Services.Exceptions;
using CIK.Assignment6.WeatherApi.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CIK.Assignment6.WeatherApi.Controllers
{
    [ApiController]
    [Route("/api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IDataFetcher _dataFetcher;
        private readonly IWeatherAnalyzerService _weatherAnalyzerService;


        public WeatherController(ILogger<WeatherController> logger, IDataFetcher dataFetcher, IWeatherAnalyzerService weatherAnalyzerService)
        {
            _logger = logger;
            _dataFetcher = dataFetcher;
            _weatherAnalyzerService = weatherAnalyzerService;
        }

        /// <summary>
        /// Get all data
        /// </summary>
        /// <param name="intervalInputModel">Data time interval</param>
        /// <returns>Returns all data</returns>
        [HttpGet("data")]
        public async Task<IActionResult> GetRawDataAsync()
        {
            try
            {
                var data = await _dataFetcher.GetData();
                return Ok(data);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        /// <summary>
        /// Returns the highest temperature within specified interval
        /// </summary>
        /// <param name="intervalInputModel">Data time interval</param>
        /// <returns>Time and value for highest temperature</returns>
        [HttpPost("highesttemperature")]
        public async Task<IActionResult> GetHighestTemperatureAsync([FromBody] DateIntervalInputModel intervalInputModel)
        {
            try
            {
                var data = await _dataFetcher.GetData();
                return Ok(_weatherAnalyzerService.HighestTemperature(data, intervalInputModel));
            }
            catch(Exception e)
            {
                return HandleException(e);
            }
        }

        /// <summary>
        /// Returns the lowest temperature within specified interval
        /// </summary>
        /// <param name="intervalInputModel">Data time interval</param>
        /// <returns>Time and value for lowest temperature</returns>
        [HttpPost("lowesttemperature")]
        public async Task<IActionResult> GetLowestTemperatureAsync([FromBody] DateIntervalInputModel intervalInputModel)
        {
            try
            {
                var data = await _dataFetcher.GetData();
                return Ok(_weatherAnalyzerService.LowestTemperature(data, intervalInputModel));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        /// <summary>
        /// Returns the average within specified interval
        /// </summary>
        /// <param name="intervalInputModel">Data time interval</param>
        /// <returns>Value for average temperature</returns>
        [HttpPost("averagetemperature")]
        public async Task<IActionResult> GetAverageTemperatureAsync([FromBody] DateIntervalInputModel intervalInputModel)
        {
            try
            {
                var data = await _dataFetcher.GetData();
                return Ok(_weatherAnalyzerService.AverageTemperature(data, intervalInputModel));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        private static IActionResult HandleException(Exception e)
        {
            switch(e)
            {
                default:
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
