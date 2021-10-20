using CIK.Assignment10.Bingo.Game.Models;
using CIK.Assignment10.Bingo.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIK.Assignment10.Bingo.Game
{
    public class BingoGame
    {
        private readonly int _totalRows;
        private readonly int _totalCols;
        private readonly IBingoCardService _bingoCardService;
        private readonly IBingoBankService _bingoBankService;

        private List<List<NumberCell>> bingoCard;

        public BingoGame(int totalRows, int totalCols, IRandom random, IBingoBankService bingoBankService, IBingoCardService bingoCardService)
        {
            _totalCols = totalCols;
            _totalRows = totalRows;
            _bingoCardService = bingoCardService;
            _bingoBankService = bingoBankService;
        }

        public bool NewGame()
        {
            bingoCard = _bingoCardService.GetGameCard(_totalRows, _totalCols);
            _bingoBankService.Reset();

            return true;
        }

        public int NextRound()
        {
            if(bingoCard == null)
            {
                return 0;
            }

            var nextNumber = _bingoBankService.Pull();
            _bingoCardService.MarkNumber(bingoCard, nextNumber);

            return nextNumber;
        }

        public List<List<string>> GetCard()
        {
            if(bingoCard == null)
            {
                return null;
            }

            var bingoCardStringRepresentation = new List<List<string>>();

            foreach (var row in bingoCard)
            {
                var rowString = new List<string>();

                foreach (var cell in row)
                {
                    rowString.Add(cell.isChecked ? "X" : cell.Value);
                }

                bingoCardStringRepresentation.Add(rowString);
            }

            return bingoCardStringRepresentation;
        }

        public bool IsBingo()
        {
            if (bingoCard == null)
            {
                return false;
            }

            return _bingoCardService.CheckForBingo(bingoCard);
        }
    }
}
