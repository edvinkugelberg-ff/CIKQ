using System;
using System.Collections.Generic;
using System.Text;

namespace CountLetters.Models
{
    public class ResultModel
    {
        public int TotalCharacters { get; set; }
        public int UpperCaseLetters { get; set; }
        public int LowerCaseLetters { get; set; }
        public int BlankSpaces { get; set; }
    }
}
