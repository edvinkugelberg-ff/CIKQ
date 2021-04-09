using CIK.Assignment5.WeatherData.Models;
using CIK.Assignment5.WeatherData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment5.WeatherData
{
    public static class ResultPresenter
    {
        public static void Present(AnalyzerResultViewModel viewModel)
        {
            if (viewModel.Time != default && viewModel.Value != default)
            {
                Console.WriteLine($"{viewModel.Type }: {viewModel.Value.Value:0.#} at {viewModel.Time.Value:dd MMM yyyy HH:mm:ss}");
            }
            else if (viewModel.Time != default)
            {
                Console.WriteLine($"{viewModel.Type }: {viewModel.Time.Value:dd MMM yyyy HH:mm:ss}");
            }
            else if (viewModel.Value != default)
            {
                Console.WriteLine($"{viewModel.Type }: {viewModel.Value.Value:0.#}");
            }

        }
    }
}
