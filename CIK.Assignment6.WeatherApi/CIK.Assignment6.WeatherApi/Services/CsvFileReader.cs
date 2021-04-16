using CIK.Assignment6.WeatherApi.Services.Exceptions;
using CIK.Assignment6.WeatherApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment6.WeatherApi.Services
{
    class CsvFileReader : IDataFetcher
    {
        private readonly string _filePath;
        private List<WeatherDataSample> _data;

        public CsvFileReader(string path)
        {
            _filePath = path;

            _data = new List<WeatherDataSample>();

            if (File.Exists(_filePath))
            {
                string[] samples = File.ReadAllLines(_filePath);

                foreach (var sample in samples)
                {
                    var splitSample = sample.Split(";");
                    var time = DateTime.Parse(splitSample[2]);
                    var value = decimal.Parse(splitSample[1], NumberStyles.Number, CultureInfo.InvariantCulture);
                    _data.Add(new WeatherDataSample(time, value));
                }
            }
            else
            {
                throw new InvalidDataSourceException($"The filepath '{_filePath}' does not exist.");
            }
        }

        public async Task<List<WeatherDataSample>> GetData()
        {
            return _data;
        }
    }
}
