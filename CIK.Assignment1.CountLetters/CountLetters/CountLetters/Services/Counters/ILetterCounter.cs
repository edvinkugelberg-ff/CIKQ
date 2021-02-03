using CountLetters.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountLetters.Services
{
    interface ILetterCounter
    {
        void Count(string input, ResultModel resultModel);
    }
}
