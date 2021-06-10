using CIK.Assignment10.Bingo.Game;
using CIK.Assignment10.Bingo.Game.Models;
using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests
{
    public class When_generating_new_round
    {
        private IRandom _random = A.Fake<IRandom>();
        private IBingoBankService _bankService = A.Fake<IBingoBankService>();
        private IBingoCardService _cardService = A.Fake<IBingoCardService>();
        private BingoGame _game;
        private bool _successfullyCreatedNewGame;
        private bool _successfullyGeneratedNewRound;
        private int _gameRowSize = 1;
        private int _gameColSize = 1;


        [OneTimeSetUp]
        public void Setup()
        {
            A.CallTo(() => _cardService.GetGameCard(A<int>._, A<int>._))
                .Returns(Data.GameCard);

            A.CallTo(() => _bankService.Pull())
                .Returns(1);

            _game = new BingoGame(_gameRowSize, _gameColSize, _random, _bankService, _cardService);
            _successfullyCreatedNewGame = _game.NewGame();
            _successfullyGeneratedNewRound = _game.NextRound();
        }

        [Test]
        public void Should_have_successfully_generated_new_round()
        {
            _successfullyGeneratedNewRound.Should().BeTrue();
        }

        [Test]
        public void Should_have_asked_for_new_number()
        {
            A.CallTo(() => _bankService.Pull())
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Should_have_marked_the_card()
        {
            A.CallTo(() => _cardService.MarkNumber(Data.GameCard, 1))
                .MustHaveHappenedOnceExactly();
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