using System;
using System.Collections.Generic;
using System.IO;
using FizzBuzz.Models;
using FizzBuzz.Services;
using FizzBuzz.Services.NumberCheckers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<INumberChecker, FizzCheck>()
                .AddSingleton<INumberChecker, BuzzCheck>()
                .AddSingleton<IKeyListService>(sp => new KeyListService(sp.GetServices<INumberChecker>()))
                .BuildServiceProvider();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var keyRange = new KeyRange();

            configuration.GetSection("NumberRangeSettings").Bind(keyRange);

            var keyListService = serviceProvider.GetService<IKeyListService>();
            var result = keyListService.ProduceKey(keyRange);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
