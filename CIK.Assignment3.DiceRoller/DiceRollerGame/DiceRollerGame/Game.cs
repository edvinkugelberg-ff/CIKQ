using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRollerGame
{
    class Game
    {
        private int _successfulGuesses;
        private Random _randomNumberGenerator;
        private int _previousRoll;
        private int _newRoll;

        public Game(Random randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public void NewGame(int diceSize)
        {
            _successfulGuesses = 0;
            _previousRoll = _randomNumberGenerator.Next(1, diceSize + 1);
            Console.WriteLine("------------------------------ NEW GAME ------------------------------");
            Console.WriteLine($"First dice shows {_previousRoll}. (h)igher or (l)ower?");
            
            var gameOver = false;
            while (gameOver == false)
            {
                var guessedHigh = ReadTwoOptionInput.ReadInput("h", "l") == "h";
                _newRoll = _randomNumberGenerator.Next(1, diceSize + 1);
                Console.WriteLine("Rolling..");
                if(CheckGuess.IsCorrectGuess(guessedHigh, _newRoll, _previousRoll))
                {
                    _successfulGuesses++;
                    Console.WriteLine($"Result was: {_newRoll}. Congratulation, you guessed right!");
                    Console.WriteLine($"{_successfulGuesses} correcet in a row! Total score is: {CalculateScore.Calculate(_successfulGuesses)}");

                    _previousRoll = _newRoll;
                    Console.WriteLine($"New dice show {_previousRoll}. (H)igher or (L)ower?");
                }
                else
                {
                    Console.WriteLine($"Result was: {_newRoll}. Your guess was incorrect!");
                    gameOver = true;
                }
            }
            Console.WriteLine("------------------------------ GAME OVER ------------------------------");
            Console.WriteLine($"Your final score was: {CalculateScore.Calculate(_successfulGuesses)}!");
            Console.WriteLine("Would you like to play again with the same dice size? (y)es or (n)o");
            if(ReadTwoOptionInput.ReadInput("y", "n") == "y")
            {
                NewGame(diceSize);
            }
        }
    }
}
