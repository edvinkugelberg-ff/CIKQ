using System;

namespace DiceRollerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new Random());
            game.NewGame(6);
        }
    }
}
