using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData.Models
{
    public class AnalyzerResultViewModel
    {
        public string Type { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Value { get; set; }
    }
}
