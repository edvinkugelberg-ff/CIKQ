namespace DiceRollerGame
{
    public static class CheckGuess
    {

        public static bool IsCorrectGuess(bool guessedHigh, int newRoll, int previousRoll)
        {
            if (guessedHigh && newRoll > previousRoll)
            {
                return true;
            }
            if (!guessedHigh && newRoll < previousRoll)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}