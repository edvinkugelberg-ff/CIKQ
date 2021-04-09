using System;
using System.Collections.Generic;
using System.Text;
using CIK.Assignment4.CardGame.Game;
using CIK.Assignment4.CardGame.Models;

namespace CIK.Assignment4.CardGame.Services
{
    public class RuleSet
    {
        private readonly IEnumerable<IRule> _rules;

        public RuleSet(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }

        public bool CheckRules(IEnumerable<Card> hand, bool verbose)
        {
            var passedAll = true;
            foreach (var rule in _rules)
            {
                if (!rule.CheckConditions(hand))
                {
                    passedAll = false;
                    if (verbose)
                    {
                        Console.WriteLine($"Hand fill the conditions specified in {rule.RuleName} rule.");
                    }
                }
            }

            return passedAll;
        }

    }
}
