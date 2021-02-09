using FizzBuzz.Models;
using System.Collections.Generic;

namespace FizzBuzz.Services
{
    public interface IKeyListService
    {
        IEnumerable<string> ProduceKey(KeyRange keyRange);
    }
}