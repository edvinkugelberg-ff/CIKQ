using System;
using System.Collections.Generic;
using System.Text;
using CIK.Assignment4.CardGame.Models;

namespace CIK.Assignment4.CardGame
{
    public interface IDeck
    {
        IEnumerable<Card> DrawRandomCards(int quantity, bool removeCards);

        int CardsLeft { get; }

    }
}
