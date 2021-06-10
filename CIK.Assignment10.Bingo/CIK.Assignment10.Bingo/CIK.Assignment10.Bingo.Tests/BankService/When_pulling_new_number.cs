using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests.BankService
{
    class When_pulling_new_number
    {
        private readonly IRandom _random = A.Fake<IRandom>();
        private IBingoBankService _bankService;
        private List<int> _result1;
        private int _result2;

        [OneTimeSetUp]
        public void Setup()
        {
            A.CallTo(() => _random.Next())
                .Returns(1);

            _bankService = new BingoBankService(_random, 5);
            _result1 = new List<int>
            {
                _bankService.Pull(),
                _bankService.Pull(),
                _bankService.Pull(),
                _bankService.Pull(),
                _bankService.Pull()
            };

            _result2 = _bankService.Pull();
        }


        [Test]
        public void Should_return_unique_numbers()
        {
            _result1.Should().BeEquivalentTo(new List<int>
            {
                1,
                2,
                3,
                4,
                5
            });
        }

        [Test]
        public void Should_return_zero_if_too_many_numbers_were_requested()
        {
            _result2.Should().Be(0);
        }
    }
}
