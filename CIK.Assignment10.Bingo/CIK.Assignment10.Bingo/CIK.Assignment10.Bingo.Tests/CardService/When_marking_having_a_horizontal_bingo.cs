using CIK.Assignment10.Bingo.Game.Models;
using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests.BankService
{
    class When_marking_having_a_horizontal_bingo
    {
        private readonly IRandom _random = A.Fake<IRandom>();
        private IBingoBankService _bankService = A.Fake<IBingoBankService>();
        private IBingoCardService _cardService;
        private List<List<NumberCell>> _card;
        private bool _result;

        [OneTimeSetUp]
        public void Setup()
        {
            A.CallTo(() => _random.Next())
                .Returns(1);

            _cardService = new BingoCardService(_random);

            _card = _cardService.GetGameCard(3, 3);
            _cardService.MarkNumber(_card, 4);
            _cardService.MarkNumber(_card, 5);
            _cardService.MarkNumber(_card, 6);
            _result = _cardService.CheckForBingo(_card);
        }


        [Test]
        public void Should_indicate_bingo()
        {
            _result.Should().BeTrue();
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
