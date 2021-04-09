namespace DiceRollerGame
{
    public static class CalculateScore
    {
        public static int Calculate(int successfulGuesses)
        {
            return successfulGuesses + ((successfulGuesses / 3) * 2);
        }
    }
}