using NUnit.Framework;
using FluentAssertions;

namespace DiceRollerGame.Tests
{
    [TestFixture]
    public class WhenCalculatingScore
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [Test]
        public void Should_return_N_points_for_N_correct_less_than_three()
        {
            CalculateScore.Calculate(1).Should().Be(1);
            CalculateScore.Calculate(2).Should().Be(2);
        }

        [Test]
        public void Should_return_5_points_for_3_correct_guesses()
        {
            CalculateScore.Calculate(3).Should().Be(5);
        }

        [Test]
        public void Should_return_25_points_for_15_correct_guesses()
        {
            CalculateScore.Calculate(15).Should().Be(25);
        }
    }
}