using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIK.Assignment4.CardGame.Models;
using CIK.Assignment4.CardGame.Services;

namespace CIK.Assignment4.CardGame.Game.Conditions
{
    public class Straight : ICondition
    {
        public bool CheckCondition(IEnumerable<Card> hand)
        {
            var orderedCards = hand.OrderBy(hand => hand.Face);

            var isStraight = orderedCards.Last().Face - orderedCards.First().Face == orderedCards.Count() - 1;

            if (!isStraight && orderedCards.First().Face == 1)
            {
                orderedCards.First().Face = 14;
                CheckCondition(orderedCards);
            }

            return isStraight;
        }
    }
}
