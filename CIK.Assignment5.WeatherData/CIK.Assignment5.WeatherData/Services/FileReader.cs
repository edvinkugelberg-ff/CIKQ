using CIK.Assignment5.WeatherData.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Services
{
    class FileReader : IDataFetcher
    {
        private readonly string _filePath;

        public FileReader(string path)
        {
            _filePath = path;
        }

        public async Task<List<WeatherDataSample>> GetData()
        {
            var data = new List<WeatherDataSample>();

            if (File.Exists(_filePath))
            {
                string[] samples = File.ReadAllLines(_filePath);

                foreach (var sample in samples)
                {
                    var splitSample = sample.Split(";");
                    var time = DateTime.Parse(splitSample[2]);
                    var value = decimal.Parse(splitSample[1], NumberStyles.Number, CultureInfo.InvariantCulture);
                    data.Add(new WeatherDataSample(time, value));
                }

            }

            return data;
        }
    }
}
