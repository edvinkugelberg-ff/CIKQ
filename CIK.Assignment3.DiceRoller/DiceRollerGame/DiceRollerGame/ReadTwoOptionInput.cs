using System;

namespace DiceRollerGame
{
    public static class ReadTwoOptionInput
    {
        public static string ReadInput(string inputOne, string inputTwo)
        {
            string input;

            do
            {
                input = Console.ReadLine();
            } while (input != inputOne && input != inputTwo);

            return input;
        }
    }
}