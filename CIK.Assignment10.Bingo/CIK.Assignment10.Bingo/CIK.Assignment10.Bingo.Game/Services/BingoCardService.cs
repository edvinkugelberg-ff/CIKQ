using CIK.Assignment10.Bingo.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK.Assignment10.Bingo.Game.Services
{
    public class BingoCardService : IBingoCardService
    {
        private readonly IRandom _random;
        private  int[] _possibleNumbers;
        private int[] _shuffledCardNumbers;

        public BingoCardService(IRandom random)
        {
            _random = random;
        }

        public List<List<NumberCell>> GetGameCard(int rowSize, int colSize)
        {
            var bingoCard = new List<List<NumberCell>>();

            for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
            {
                bingoCard.Add(new List<NumberCell>());

                for (int colIndex = 0; colIndex < colSize; colIndex++)
                {
                    bingoCard[rowIndex].Add(new NumberCell());
                }
            }

            PopulateCells(bingoCard);

            return bingoCard;
        }

        private bool PopulateCells(List<List<NumberCell>> cells)
        {
            _possibleNumbers = Enumerable.Range(1, cells.Count*cells[0].Count).ToArray();
            _shuffledCardNumbers = _possibleNumbers.OrderBy(x => _random.Next()).ToArray();

            var index = 0;

            foreach (var row in cells)
            {
                foreach (var cell in row)
                {
                    cell.Value = _shuffledCardNumbers[index].ToString();
                    cell.isChecked = false;

                    index++;
                }
            }

            return true;
        }

        public void MarkNumber(List<List<NumberCell>> gameCard, int number)
        {
            var index = Array.IndexOf(_shuffledCardNumbers, number);

            var row = index / gameCard[0].Count;
            var column = index % gameCard[0].Count;

            gameCard[row][column].isChecked = true;
        }

        public bool CheckForBingo(List<List<NumberCell>> gameCard)
        {
            return CheckForRowBingo(gameCard) || CheckForColumnBingo(gameCard);

        }

        private bool CheckForRowBingo(List<List<NumberCell>> gameCard)
        {
            foreach (var row in gameCard)
            {
                var rowBingo = true;

                foreach (var cell in row)
                {
                    if (cell.isChecked == false)
                    {
                        rowBingo = false;
                    }
                }

                if (rowBingo)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckForColumnBingo(List<List<NumberCell>> gameCard)
        {
            for (int col = 0; col < gameCard[0].Count; col++)
            {
                var colBingo = true;

                foreach (var row in gameCard)
                {
                    if(row[col].isChecked == false)
                    {
                        colBingo = false;
                    }
                }

                if (colBingo)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
