using CountLetters.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountLetters.Services
{
    public class PresentResultService
    {
        public static void Present(ResultModel resultModel)
        {
            Console.WriteLine("\nResult:");
            Console.WriteLine(" Total Number of Characters:".PadRight(45, '.') + $"{resultModel.TotalCharacters}");
            Console.WriteLine("Extra Credit:");
            Console.WriteLine(" Total Number of Upper Case Characters:".PadRight(45, '.') + $"{resultModel.UpperCaseLetters}");
            Console.WriteLine(" Total Number of Lower Case Characters:".PadRight(45, '.') + $"{resultModel.LowerCaseLetters}");
            Console.WriteLine(" Total Number of Blank Space Characters:".PadRight(45, '.') + $"{resultModel.BlankSpaces}");
        }
    }
}
