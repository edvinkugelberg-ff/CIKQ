using CIK.Assignment10.Bingo.Game.Models;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Game.Services
{
    public interface IBingoCardService
    {
        List<List<NumberCell>> GetGameCard(int rowSize, int colSize);
        void MarkNumber(List<List<NumberCell>> gameCard, int number);
        bool CheckForBingo(List<List<NumberCell>> gameCard);
    }
}