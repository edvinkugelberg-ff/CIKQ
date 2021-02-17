using FakeItEasy;
using FizzBuzz.Models;
using FizzBuzz.Services;
using FizzBuzz.Services.NumberCheckers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Tests.ServicesTests
{
    [TestFixture]
    class When_calling_key_list_service
    {
        private readonly INumberChecker _buzzCheck = A.Fake<INumberChecker>();
        private readonly INumberChecker _fizzCheck = A.Fake<INumberChecker>();
        private IKeyListService _keyListService;
        private IEnumerable<string> _result;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            A.CallTo(() => _buzzCheck.Check(0)).Returns("Buzz");
            A.CallTo(() => _buzzCheck.Check(5)).Returns("Buzz");
            A.CallTo(() => _buzzCheck.Check(10)).Returns("Buzz");

            A.CallTo(() => _fizzCheck.Check(0)).Returns("Fizz");
            A.CallTo(() => _fizzCheck.Check(3)).Returns("Fizz");
            A.CallTo(() => _fizzCheck.Check(6)).Returns("Fizz");
            A.CallTo(() => _fizzCheck.Check(9)).Returns("Fizz");

            _keyListService = new KeyListService(new List<INumberChecker> { _fizzCheck, _buzzCheck });

            _result = _keyListService.ProduceKey(Data.KeyRange);
        }

        [Test]
        public void Should_procude_the_correct_key()
        {
            _result.Should().BeEquivalentTo(Data.ExpectedResult);
        }

        [Test]
        public void Sould_have_called_fizz_check_n_times()
        {
            A.CallTo(() => _fizzCheck.Check(A<int>.Ignored)).MustHaveHappened(11, Times.Exactly);
        }

        [Test]
        public void Sould_have_called_buzz_check_n_times()
        {
            A.CallTo(() => _buzzCheck.Check(A<int>.Ignored)).MustHaveHappened(11, Times.Exactly);
        }

        private static class Data
        {
            public static readonly KeyRange KeyRange = new KeyRange
            {
                KeyStart = 0,
                KeyStop = 10
            };

            public static readonly List<string> ExpectedResult = new List<string>
            {
                "FizzBuzz",
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz",
                "Fizz",
                "7",
                "8",
                "Fizz",
                "Buzz",
            };
        }
    }
}
