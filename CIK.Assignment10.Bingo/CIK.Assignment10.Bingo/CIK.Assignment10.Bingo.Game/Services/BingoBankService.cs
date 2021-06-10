using System.Linq;

namespace CIK.Assignment10.Bingo.Game.Services
{
    public class BingoBankService : IBingoBankService
    {
        private readonly IRandom _random;
        private readonly int _cellCount;
        private readonly int[] _possibleNumbers;
        private int[] _shuffledBankNumbers;
        private int _pullIndex;

        public BingoBankService(IRandom random, int cellCount)
        {
            _random = random;
            _cellCount = cellCount;
            _possibleNumbers = Enumerable.Range(1, cellCount).ToArray();
            _shuffledBankNumbers = _possibleNumbers.OrderBy(x => _random.Next()).ToArray();
            _pullIndex = 0;
        }

        public int Pull()
        {
            if (_pullIndex < _cellCount)
            {
                var pulledNumber = _shuffledBankNumbers[_pullIndex];
                _pullIndex++;
            
                return pulledNumber;
            }
            else
            {
                return 0;
            }
        }

        public void Reset()
        {
            _pullIndex = 0;
            _shuffledBankNumbers = _possibleNumbers.OrderBy(x => _random.Next()).ToArray();
        }

    }
}
