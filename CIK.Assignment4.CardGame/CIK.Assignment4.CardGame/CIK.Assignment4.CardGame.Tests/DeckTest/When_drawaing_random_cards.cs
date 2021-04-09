using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CIK.Assignment4.CardGame.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CIK.Assignment4.CardGame.Tests.DeckTest
{
    class When_drawaing_random_cards
    {
        private readonly Random _rng = new Random();
        private IDeck _deckOfCards;

        private IEnumerable<Card> _hand;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _deckOfCards = new DeckOfCards(Data.DeckOfCards, _rng);

            _hand = _deckOfCards.DrawRandomCards(2, true);
        }

        [Test]
        public void Should_remove_drawn_cards_if_specified()
        {
            _deckOfCards.CardsLeft.Should().Be(1);
        }


        private static class Data
        {
            public static readonly List<Card> DeckOfCards =
                new List<Card>
                {
                    new Card {Face = 1, Suit = Enums.Suit.Clubs},
                    new Card {Face = 1, Suit = Enums.Suit.Clubs},
                    new Card {Face = 1, Suit = Enums.Suit.Clubs}
                };
        };
    }
}
