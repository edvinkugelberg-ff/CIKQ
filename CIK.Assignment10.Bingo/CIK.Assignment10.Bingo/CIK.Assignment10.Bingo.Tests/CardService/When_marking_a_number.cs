using CIK.Assignment10.Bingo.Game.Models;
using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests.CardService
{
    class When_marking_a_number
    {
        private readonly IRandom _random = A.Fake<IRandom>();
        private IBingoBankService _bankService = A.Fake<IBingoBankService>();
        private IBingoCardService _cardService;
        private List<List<NumberCell>> _card;

        [OneTimeSetUp]
        public void Setup()
        {
            A.CallTo(() => _random.Next())
                .Returns(1);

            _cardService = new BingoCardService(_random);

            _card = _cardService.GetGameCard(3, 3);
        }


        [Test]
        public void Should_mark_the_correct_cells()
        {
            _cardService.MarkNumber(_card, 1);
            Data.GameCard[0][0].isChecked = true;
            _card.Should().BeEquivalentTo(Data.GameCard);

            _cardService.MarkNumber(_card, 2);
            Data.GameCard[0][1].isChecked = true;
            _card.Should().BeEquivalentTo(Data.GameCard);

            _cardService.MarkNumber(_card, 3);
            Data.GameCard[0][2].isChecked = true;
            _card.Should().BeEquivalentTo(Data.GameCard);

            _cardService.MarkNumber(_card, 5);
            Data.GameCard[1][1].isChecked = true;
            _card.Should().BeEquivalentTo(Data.GameCard);

            _cardService.MarkNumber(_card, 6);
            Data.GameCard[1][2].isChecked = true;
            _card.Should().BeEquivalentTo(Data.GameCard);

            _cardService.MarkNumber(_card, 9);
            Data.GameCard[2][2].isChecked = true;
            _card.Should().BeEquivalentTo(Data.GameCard);
        }

        private class Data
        {
            public static readonly List<List<NumberCell>> GameCard = new List<List<NumberCell>>
            {
                new List<NumberCell>
                {
                    new NumberCell
                    {
                        Value = "1",
                        isChecked = false
                    },
                    new NumberCell
                    {
                        Value = "2",
                        isChecked = false
                    },
                    new NumberCell
                    {
                        Value = "3",
                        isChecked = false
                    },
                },
                new List<NumberCell>
                {
                    new NumberCell
                    {
                        Value = "4",
                        isChecked = false
                    },
                    new NumberCell
                    {
                        Value = "5",
                        isChecked = false
                    },
                    new NumberCell
                    {
                        Value = "6",
                        isChecked = false
                    },
                },
                new List<NumberCell>
                {
                    new NumberCell
                    {
                        Value = "7",
                        isChecked = false
                    },
                    new NumberCell
                    {
                        Value = "8",
                        isChecked = false
                    },
                    new NumberCell
                    {
                        Value = "9",
                        isChecked = false
                    },
                }
            };
        }
    }
}
