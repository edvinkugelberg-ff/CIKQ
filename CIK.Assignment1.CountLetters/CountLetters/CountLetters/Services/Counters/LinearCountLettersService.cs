using CountLetters.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountLetters.Services
{
    public class LinearCountLettersService : ILetterCounter
    {

        public void Count(string input, ResultModel resultModel)
        {
            resultModel.TotalCharacters = input.Length;

            foreach (var character in input)
            {
                if (char.IsUpper(character))
                {
                    resultModel.UpperCaseLetters++;
                }
                else if (char.IsLower(character))
                {
                    resultModel.LowerCaseLetters++;
                }
                else if (char.IsWhiteSpace(character))
                {
                    resultModel.BlankSpaces++;
                }

            }
        }
    }
}
