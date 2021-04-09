using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIK.Assignment4.CardGame.Models;

namespace CIK.Assignment4.CardGame
{
    public class DeckOfCards : IDeck
    {
        private readonly Random _rng;
        public List<Card> Cards { get; }

        public int CardsLeft => Cards.Count();


        public DeckOfCards(List<Card> cards, Random rng)
        {
            Cards = cards;
            _rng = rng;
        }

        public IEnumerable<Card> DrawRandomCards(int quantity, bool removeCards)
        {
            var selectedIndexes = GetRandomIndex(quantity);

            var result = new List<Card>();

            if (selectedIndexes == default) return result;

            result.AddRange(selectedIndexes.Select(index => Cards[index]));

            if (removeCards)
            {
                foreach (var index in selectedIndexes)
                {
                    Cards.RemoveAt(index);
                }
            }
            

            return result;
        }

        private IEnumerable<int> GetRandomIndex(int quantity)
        {
            if (quantity > Cards.Count())
            {
                return default;
            }

            var selectedCards = new List<int>();

            while (selectedCards.Count < quantity)
            {
                var cardIndex = _rng.Next(0, Cards.Count());
                if (!selectedCards.Contains(cardIndex))
                {
                    selectedCards.Add(cardIndex);
                }
            }

            return selectedCards;
        }

    }
}
