using CountLetters.Models;
using CountLetters.Services;
using System;

namespace CountLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input string:");
            var input = Console.ReadLine();

            var resultModel = new ResultModel();

            //ILetterCounter letterCounter = new LinearCountLettersService();
            //ILetterCounter letterCounter = new LinqCountLettersService();
            ILetterCounter letterCounter = new RegexCountLettersService();

            letterCounter.Count(input, resultModel);

            PresentResultService.Present(resultModel);

            Console.ReadLine();
        }
    }
}
