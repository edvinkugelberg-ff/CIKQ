using CountLetters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountLetters.Services
{
    public class LinqCountLettersService : ILetterCounter
    {
        public void Count(string input, ResultModel resultModel)
        {
            var characters = input.ToCharArray();
            resultModel.TotalCharacters = characters.Length;
            resultModel.UpperCaseLetters = characters.Where(c => Char.IsUpper(c)).Count();
            resultModel.LowerCaseLetters = characters.Where(c => Char.IsLower(c)).Count();
            resultModel.BlankSpaces = characters.Where(c => Char.IsWhiteSpace(c)).Count();
        }
    }
}
