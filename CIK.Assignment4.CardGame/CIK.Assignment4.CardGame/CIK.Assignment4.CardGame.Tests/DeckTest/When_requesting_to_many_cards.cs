using System;
using System.Collections.Generic;
using System.Text;
using CIK.Assignment4.CardGame.Models;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace CIK.Assignment4.CardGame.Tests.DeckTest
{
    class When_requesting_to_many_cards
    {
        private readonly Random _rng = new Random();
        private IDeck _deckOfCards;

        private IEnumerable<Card> _hand;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _deckOfCards = new DeckOfCards(Data.DeckOfCards, _rng);

            _hand = _deckOfCards.DrawRandomCards(5);

        }

        [Test]
        public void Should_return_default()
        {
            _hand.Should().BeNullOrEmpty();
        }

        private static class Data
        {
            public static readonly List<Card> DeckOfCards =
                new List<Card>
                {
                    new Card {Face = 1, Suit = Enums.Suit.Clubs}
                };
        };
    }
}