using CIK.Assignment5.WeatherData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Models
{
    class AnalysisSteps
    {
        public ITemperatureAnalyzer[] Steps { get; set; }
    }
}
