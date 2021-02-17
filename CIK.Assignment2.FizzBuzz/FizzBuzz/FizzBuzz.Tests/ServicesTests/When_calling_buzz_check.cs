using FizzBuzz.Services.NumberCheckers;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests.ServicesTests
{
    [TestFixture]
    public class When_calling_buzz_check
    {
        private INumberChecker _buzzCheck;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _buzzCheck = new BuzzCheck();
        }

        [Test]
        public void Should_return_buzz_if_divisible_by_five()
        {
            _buzzCheck.Check(5).Should().Be("Buzz");
            _buzzCheck.Check(10).Should().Be("Buzz");
            _buzzCheck.Check(25).Should().Be("Buzz");
        }

        [Test]
        public void Should_return_null_if_NOT_divisible_by_five()
        {
            _buzzCheck.Check(7).Should().Be(null);
            _buzzCheck.Check(9).Should().Be(null);
            _buzzCheck.Check(31).Should().Be(null);
        }

        [Test]
        public void Should_return_buzz_if_input_is_zero()
        {
            _buzzCheck.Check(0).Should().Be("Buzz");
        }

    }
}