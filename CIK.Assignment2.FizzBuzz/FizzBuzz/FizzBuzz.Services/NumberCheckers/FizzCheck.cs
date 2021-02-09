using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Services.NumberCheckers
{
    public class FizzCheck : INumberChecker
    {
        public string Check(int number)
        {
            return number % 3 == 0 ? "Fizz" : default;
        }
    }
}
