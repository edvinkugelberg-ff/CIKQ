using CIK.Assignment10.Bingo.Game.Services;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CIK.Assignment10.Bingo.Tests.BankService
{
    class When_resetting_service
    {
        private readonly IRandom _random = A.Fake<IRandom>();
        private IBingoBankService _bankService;
        private List<int> _result1;
        private List<int> _result2;

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

            _bankService.Reset();

            _result2 = new List<int>
            {
                _bankService.Pull(),
                _bankService.Pull(),
                _bankService.Pull(),
                _bankService.Pull(),
                _bankService.Pull()
            };
        }


        [Test]
        public void Should_return_same_numbers()
        {
            _result1.Should().BeEquivalentTo(_result2);
        }
    }
}
