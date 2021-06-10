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

        public List<List<NumberCell>> bingoCard { get;  private set; }

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

        public bool NextRound()
        {
            if(bingoCard == null)
            {
                return false;
            }

            var nextNumber = _bingoBankService.Pull();
            _bingoCardService.MarkNumber(bingoCard, nextNumber);

            return true;
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
