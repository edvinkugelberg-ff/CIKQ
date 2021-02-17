using FizzBuzz.Services.NumberCheckers;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.Tests.ServicesTests
{
    [TestFixture]
    public class When_calling_fizz_check
    {
        private INumberChecker _fizzCheck;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _fizzCheck = new FizzCheck();
        }

        [Test]
        public void Should_return_buzz_if_divisible_by_five()
        {
            _fizzCheck.Check(3).Should().Be("Fizz");
            _fizzCheck.Check(12).Should().Be("Fizz");
            _fizzCheck.Check(18).Should().Be("Fizz");
        }

        [Test]
        public void Should_return_null_if_NOT_divisible_by_five()
        {
            _fizzCheck.Check(7).Should().Be(null);
            _fizzCheck.Check(11).Should().Be(null);
            _fizzCheck.Check(31).Should().Be(null);
        }

        [Test]
        public void Should_return_fizz_if_input_is_zero()
        {
            _fizzCheck.Check(0).Should().Be("Fizz");
        }

    }
}