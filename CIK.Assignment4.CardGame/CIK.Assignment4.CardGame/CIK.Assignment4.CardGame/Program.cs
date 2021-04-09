using System;
using System.Collections.Generic;
using System.Diagnostics;
using CIK.Assignment4.CardGame.Game;
using CIK.Assignment4.CardGame.Game.Conditions;
using CIK.Assignment4.CardGame.Models;
using CIK.Assignment4.CardGame.Services;

namespace CIK.Assignment4.CardGame
{
    class Program
    {

        static void Main(string[] args)
        {
            var cards = new List<Card>();

            for (var i = 1; i < 14; i++)
            {
                foreach (Enums.Suit suit in Enum.GetValues(typeof(Enums.Suit)))
                {
                    cards.Add(new Card()
                    {
                        Face = i,
                        Suit = suit,
                    });
                }
            }

            var rng = new Random();
            IDeck deckOfCards = new DeckOfCards(cards, rng);

            var straightFlush = new Rule(new List<ICondition>
            {
                new Straight(), new Flush()
            }, "Straight Flush");

            var ruleSet = new RuleSet(new List<IRule> {straightFlush});



            var gameEnd = false;
            var tries = 0;

            var stopwatch = Stopwatch.StartNew();
            while (!gameEnd)
            {
                var hand = deckOfCards.DrawRandomCards(5, false);

                if (ruleSet.CheckRules(hand, false))
                {
                    gameEnd = true;
                    Console.WriteLine($"Found a straight flush after {stopwatch.Elapsed.TotalSeconds} seconds and {tries} tries:");
                    foreach (var card in hand)
                    {
                        Console.WriteLine($"{card.Face} of {card.Suit}");
                    }
                }

                tries++;
            }

        }
    }
}
