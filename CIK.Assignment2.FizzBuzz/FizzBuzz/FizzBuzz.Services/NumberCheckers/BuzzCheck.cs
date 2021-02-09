using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Services.NumberCheckers
{
    public class BuzzCheck : INumberChecker
    {
        public string Check(int number)
        {
            return number % 5 == 0 ? "Buzz" : default;
        }
    }
}
