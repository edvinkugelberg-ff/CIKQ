using CIK.Assignment10.Bingo.Game.Models;
using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests.CardService
{
    class When_generating_new_card
    {
        private readonly IRandom _random = A.Fake<IRandom>();
        private IBingoCardService _cardService;
        private List<List<NumberCell>> _result;

        [OneTimeSetUp]
        public void Setup()
        {
            A.CallTo(() => _random.Next())
                .Returns(1);

            _cardService = new BingoCardService(_random);

            _result = _cardService.GetGameCard(1, 5);
        }


        [Test]
        public void Should_generated_random_card()
        {
            _result.Should().BeEquivalentTo(Data.GameCard);
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
                }
            };
        }
    }
}
