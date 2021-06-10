using CIK.Assignment10.Bingo.Game;
using CIK.Assignment10.Bingo.Game.Models;
using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests
{
    public class When_creating_new_game
    {
        private IRandom _random = A.Fake<IRandom>();
        private IBingoBankService _bankService = A.Fake<IBingoBankService>();
        private IBingoCardService _cardService = A.Fake<IBingoCardService>();
        private BingoGame _game;
        private bool _successfullyCreatedNewGame;
        private int _gameRowSize = 1;
        private int _gameColSize = 1;


        [OneTimeSetUp]
        public void Setup()
        {
            A.CallTo(() => _cardService.GetGameCard(A<int>._, A<int>._))
                .Returns(new List<List<NumberCell>>());

            _game = new BingoGame(_gameRowSize, _gameColSize, _random, _bankService, _cardService);
            _successfullyCreatedNewGame = _game.NewGame();
        }

        [Test]
        public void Should_have_called_get_game_card_service()
        {
            A.CallTo(() => _cardService.GetGameCard(_gameRowSize, _gameColSize))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Should_have_reset_bank_service()
        {
            A.CallTo(() => _bankService.Reset())
                .MustHaveHappenedOnceExactly();
        }
        
        [Test]
        public void Should_succesfully_created_new_game()
        {
            _successfullyCreatedNewGame.Should().BeTrue();
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