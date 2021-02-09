using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Services.NumberCheckers
{
    public interface INumberChecker
    {
        string Check(int number);
    }
}
