using CountLetters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CountLetters.Services
{
    public class RegexCountLettersService : ILetterCounter
    {

        public void Count(string input, ResultModel resultModel)
        {
            resultModel.TotalCharacters = input.Length;

            resultModel.UpperCaseLetters = Regex.Matches(input, "[A-ZÅÄÖ]").Count();
            resultModel.LowerCaseLetters = Regex.Matches(input, "[a-zåäö]").Count();
            resultModel.BlankSpaces = Regex.Matches(input, " ").Count();
        }
    }
}
