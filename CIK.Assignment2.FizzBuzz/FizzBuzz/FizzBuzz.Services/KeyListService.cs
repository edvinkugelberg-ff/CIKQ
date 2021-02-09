using FizzBuzz.Models;
using FizzBuzz.Services.NumberCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz.Services
{
    public class KeyListService : IKeyListService
    {
        private readonly IEnumerable<INumberChecker> _numberCheckers;

        public KeyListService(IEnumerable<INumberChecker> numberCheckers)
        {
            _numberCheckers = numberCheckers;
        }

        public IEnumerable<string> ProduceKey(KeyRange keyRange)
        {
            var key = new List<string>();

            for (int number = keyRange.KeyStart; number <= keyRange.KeyStop; number++)
            {
                var checkResult = CheckNumber(number);
                key.Add(!string.IsNullOrEmpty(checkResult) ? checkResult : number.ToString());
            }

            return key;
        }

        private string CheckNumber(int number)
        {
            var stringBuilder = new StringBuilder();

            foreach (var numberchecker in _numberCheckers)
            {
                stringBuilder.Append(numberchecker.Check(number));
            }

            return stringBuilder.ToString();
        }
    }
}
