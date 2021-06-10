using CIK.Assignment10.Bingo.Game.Models;
using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests.CardService
{
    class When_not_having_bingo
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

            _result = _cardService.CheckForBingo(_card);
        }

        [Test]
        public void Should_not_detect_bingo()
        {
            _result.Should().BeFalse();
        }
    }
}
