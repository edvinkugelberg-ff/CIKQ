using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment10.Bingo.Game.Services
{
    public class RandomNumberGenerator : IRandom
    {
        private readonly Random _random;

        public RandomNumberGenerator()
        {
            _random = new Random();
        }

        public int Next()
        {
            return _random.Next();
        }
    }
}
