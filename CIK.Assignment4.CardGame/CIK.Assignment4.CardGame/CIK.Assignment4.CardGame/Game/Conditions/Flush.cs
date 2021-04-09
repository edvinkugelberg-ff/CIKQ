using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIK.Assignment4.CardGame.Models;
using CIK.Assignment4.CardGame.Services;

namespace CIK.Assignment4.CardGame.Game.Conditions
{
    public class Flush : ICondition
    {
        public bool CheckCondition(IEnumerable<Card> hand)
        {
            var checkSuit = hand.First().Suit;

            foreach (var card in hand)
            {
                if (card.Suit != checkSuit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
