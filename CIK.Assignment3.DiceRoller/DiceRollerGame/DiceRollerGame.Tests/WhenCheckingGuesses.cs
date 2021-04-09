using NUnit.Framework;
using FluentAssertions;

namespace DiceRollerGame.Tests
{
    [TestFixture]
    public class WhenCheckingGuesses
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [Test]
        public void Should_return_false_if_guessed_higher_but_was_lower()
        {
            CheckGuess.IsCorrectGuess(true, 2, 5).Should().Be(false);
        }
        [Test]
        public void Should_return_true_if_guessed_higher_and_was_higher()
        {
            CheckGuess.IsCorrectGuess(true, 6, 5).Should().Be(true);
        }
        [Test]
        public void Should_return_false_if_result_was_same()
        {
            CheckGuess.IsCorrectGuess(true, 5, 5).Should().Be(false);
        }
        [Test]
        public void Should_return_false_if_guessed_lower_and_was_higher()
        {
            CheckGuess.IsCorrectGuess(false, 5, 6).Should().Be(true);
        }
        [Test]
        public void Should_return_true_if_guessed_lower_and_was_lower()
        {
            CheckGuess.IsCorrectGuess(false, 5, 6).Should().Be(true);
        }
    }
}